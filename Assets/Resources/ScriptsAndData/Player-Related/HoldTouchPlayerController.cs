using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoldTouchPlayerController : MonoBehaviour
{
    private Touch touch;
    private Vector3 touchPosition;

    private Rigidbody2D rb;
    private Vector3 direction;
    private float speed = 5f;

    private bool isFalling = false;

    private bool isBuilding = false;
    private Vector3 firstTouchPosition = Vector3.one * -1;
    private float waitCounter = 0;
    public float swipeFactor = 0.5f;


    private BoxCollider2D boxCollider;
    private PolygonCollider2D polyCollider;

    public BlockManager blockManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polyCollider = GetComponent<PolygonCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        TouchControls();
    }

   private void UpdateTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    }

    private void TouchControls()
    {
        bool notTouchingUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.touchCount > 0 && notTouchingUI)
        {
            UpdateTouchPosition();
            PlayerTriggerMoving();
            UpdateBuilding();
            if (touch.phase == TouchPhase.Ended)
            {
                MovePlayerObject(0);
            }
        }
        else
        {
            ResetBuildingWait();
        }
    }

    #region Build Interaction
    private bool CheckSpriteTouched()
    {
        return polyCollider == Physics2D.OverlapPoint(touchPosition) ||
                                   boxCollider == Physics2D.OverlapPoint(touchPosition);
    }
    private void PlayerTriggerBuilding()
    {
        if (isBuilding)
        {
            float heightBlockOffset = blockManager.Build(transform.position);
            transform.position += new Vector3(0, heightBlockOffset);
        }
        isBuilding = false;
    }
    private void CheckBuildingAllowed(bool isTouchingSprite)
    {
        if (isTouchingSprite
                   && !isBuilding)
        {
            if (waitCounter > 15)
            {
                isBuilding = blockManager.canBuild();
                ResetBuildingWait();
            }
            else
            {
                waitCounter++;
            }
        }
    }
    private void ResetBuildingWait()
    {
        waitCounter = 0;
        firstTouchPosition = Vector3.one * -1;
    }

    private void UpdateBuilding()
    {
        //Dealing with Building
        bool isTouchingSprite = CheckSpriteTouched();
        CheckBuildingAllowed(isTouchingSprite);
    }
    #endregion

    #region Move Interaction
    private void PlayerTriggerMoving()
    {
        isFalling = !rb.IsTouchingLayers();
        Vector3 movePosition = new Vector3(touchPosition.x, touchPosition.y);
        movePosition.y = 0;

        if (!isFalling && boxCollider.IsTouchingLayers())
        {
            direction = movePosition - transform.position;
            MovePlayerObject(direction.x);
        }

    }
    private void MovePlayerObject(float horizontalDirection)
    {
        Vector2 newVelocity = new Vector2(horizontalDirection * speed, rb.velocity.y);
        rb.velocity = newVelocity;
    }

    #endregion


    void FixedUpdate()
    {
        PlayerTriggerBuilding();
    }
}
