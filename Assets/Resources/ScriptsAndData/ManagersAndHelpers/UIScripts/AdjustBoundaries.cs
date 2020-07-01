using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustBoundaries : MonoBehaviour
{
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Ground;
    public Camera targetCam;


    private Vector2 screenBounds;

    void Start()
    {
        AdjustGroundAndWalls();
    }

    private void Awake()
    {
        AdjustGroundAndWalls();
    }
    
    private void AdjustGroundAndWalls()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, targetCam.transform.position.z));
        LeftWall.transform.position = new Vector2(-screenBounds.x-0.7f, screenBounds.y / 2);
        RightWall.transform.position = new Vector2(screenBounds.x+0.7f, screenBounds.y / 2);
        Ground.transform.position = new Vector2(screenBounds.x/2, -screenBounds.y+2.8f);
    }

}
