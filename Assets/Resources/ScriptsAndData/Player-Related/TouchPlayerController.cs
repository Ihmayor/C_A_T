using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPlayerController : MonoBehaviour
{
    private Touch touch; 
    private Vector3 touchPosition;
    private Vector3 direction;
    private float speed = 10f;
    
    private bool isFalling;
    private bool isBuilding = false;
    private bool isFirstBuild = true;
    private int BlocksBuilt = 0;
    [SerializeField]
    private BooleanVariable isButtonBuilding;

    private Vector3 firstTouchPosition = Vector3.one * -1;
    private float buildWaitCounter = 0;
    
    [SerializeField]
    private FloatVariable waitFactor;
    [SerializeField]
    private FloatVariable swipeDownFactor;

    private float swipeMoveLimit = 1.5f;

    private BoxCollider2D boxCollider;
    private PolygonCollider2D polyCollider;

    public BlockManager blockManager;

    public UnityEvent OnFirstBuild;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        polyCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        polyCollider = GetComponent<PolygonCollider2D>();
        TouchControls();
    }

    void FixedUpdate()
    {
        PlayerTriggerBuilding();
    }

    public void ResetPlayerPosition(LevelDataVariable currentLevel)
    {
        isFirstBuild = true;
        BlocksBuilt = 0;
        this.gameObject.transform.position = currentLevel.Data.playerStartPosiiton;
    }

    public void isCollisionsOn(bool setCollisions)
    {
        GetComponent<PolygonCollider2D>().enabled = setCollisions;
        GetComponent<BoxCollider2D>().enabled = setCollisions;
    }

    private void TouchControls()
    {
        bool notTouchingUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.touchCount > 0 && notTouchingUI)
        {
            UpdateTouchPosition();
            PlayerTriggerMoving();
        //  CheckBuildingAllowed();
            
            if (touch.phase == TouchPhase.Ended)
            {
                MovePlayerObject(0);
            }
        }
        else
        {
            ResetBuildingWait();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void UpdateTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    }

 
    #region Build Interaction
    private void ResetBuildingWait()
    {
        buildWaitCounter = 0;
        firstTouchPosition = Vector3.one * -1;
    }

    private void CheckBuildingAllowed()
    {
        Vector3 newDragPosition = new Vector3(touchPosition.x, touchPosition.y);
        if (!isBuilding && GetComponent<Float>() == null)
        {
            float swipeDistance = Mathf.Abs(firstTouchPosition.y - newDragPosition.y);
            if (buildWaitCounter >= waitFactor.Value)
            {
                if (firstTouchPosition.x == -1)
                {
                    firstTouchPosition = newDragPosition;
                }
                else
                {
                    float distance = Mathf.Abs(Vector3.Distance(touchPosition, transform.position));
                    bool isNotSwipingToMove = distance <= swipeMoveLimit;
                    bool isSwipeBuilding = swipeDistance >= swipeDownFactor.Value && isNotSwipingToMove;
                    if (isSwipeBuilding)
                    {
                        isBuilding = blockManager.canBuild();
                        ResetBuildingWait();
                    }
                }
            }
            else
            {
                buildWaitCounter+=0.02f;
            }
        }

    }

    private void PlayerTriggerBuilding()
    {
        if (isBuilding || isButtonBuilding.Value&& blockManager.canBuild())
        {
            float heightBlockOffset = blockManager.Build(transform.position);
            Vector3 newPos = transform.position + new Vector3(0, heightBlockOffset);
            StartCoroutine(SmoothPosition(newPos, 0.2f));
            if (isFirstBuild && BlocksBuilt >= 1 && !blockManager.tutorialMode)
            {
                OnFirstBuild.Invoke();
                isFirstBuild = false;
            }
            else if (isFirstBuild)
            {
                BlocksBuilt++;
            }
            isButtonBuilding.Value = false;
        }
        isBuilding = false;
    }
    private IEnumerator SmoothPosition(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    #endregion

    #region Move Interaction
    private void PlayerTriggerMoving()
    {
        Vector3 movePosition = new Vector3(touchPosition.x, touchPosition.y);
        movePosition.y = 0;

        bool onGround = !isFalling && boxCollider.IsTouchingLayers();
        bool isFloating = GetComponent<Float>();

        if ( (onGround || isFloating ) && CheckSpriteTouched())
        {
            direction = movePosition - transform.position;
            MovePlayerObject(direction.x);
        }
    }

    private void MovePlayerObject(float horizontalDirection)
    {
        Vector2 newVelocity = new Vector2(horizontalDirection * speed, 0);
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }

    private bool CheckSpriteTouched()
    {
        return polyCollider == Physics2D.OverlapPoint(touchPosition) ||
                                   boxCollider == Physics2D.OverlapPoint(touchPosition);
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFalling = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!boxCollider.IsTouchingLayers())
            isFalling = true;
    }

}
