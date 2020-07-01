using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GyroPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 0.0010f;

    private bool isFalling = false;

    private bool isBuilding = false;
    private float waitCounter;


    public BlockManager blockManager;



    public Text AttitudeLine;
    public Text AccelerationLine;
    public Text RotationRate;
    public Text Gravity;


    public BlockElementData debuggingBlock;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AttitudeLine.text = "Attitude: " + Input.gyro.attitude;
        AccelerationLine.text = "Acceleration: " + Input.gyro.userAcceleration;
        RotationRate.text = "Rotation Rate: " + Input.gyro.rotationRate;
        Gravity.text = "Gravity: "+Input.gyro.gravity;
        GyroControls();
    }


    private void GyroControls()
    {
        isFalling = !rb.IsTouchingLayers();
        GyroMove();
        GyroBuild();
    }

    private void GyroMove()
    {
        if (!isFalling)
        {
            float horizontalDirection = Input.gyro.rotationRate.y;
            MovePlayerObject(horizontalDirection);

        }
    }


    private void GyroBuild()
    {
        if (waitCounter >=0  & !isFalling)
        {
            Rotation_CheckBuildingAllowed();
            waitCounter = 0;
        }
        else
        {
            waitCounter++;
        }
    }

    private void ResetBuildingWait()
    {
        waitCounter = 0;
    }
   
    private void MovePlayerObject(float horizontalDirection)
    {
        Vector2 newVelocity = new Vector2(horizontalDirection * speed, 0);
        rb.velocity = newVelocity;
    }

    private void PlayerTriggerBuilding(BlockElementData data)
    {
        if (isBuilding)
        {
            float heightBlockOffset = blockManager.Build(debuggingBlock, transform.position);
            transform.position += new Vector3(0, heightBlockOffset);
        }
        isBuilding = false;
    }


    private void Attitude_CheckBuildingAllowed()
    {
        isFalling = !rb.IsTouchingLayers();
        float gyroXAttitude = Input.gyro.attitude.x;
        if (!isBuilding)
        {
            if (gyroXAttitude > 0.3f)
            {
                isBuilding = true;
                ResetBuildingWait();
            }
        }
    }

    private void Rotation_CheckBuildingAllowed()
    {
        isFalling = !rb.IsTouchingLayers();
        float gyroRotation = Input.gyro.rotationRate.z;
        if (!isBuilding)
        {
            if (Mathf.Abs(gyroRotation) > 0.8f)
            {
                isBuilding = true;
                ResetBuildingWait();
            }
        }

    }

    private void FixedUpdate()
    {
        PlayerTriggerBuilding(debuggingBlock);
    }


}
