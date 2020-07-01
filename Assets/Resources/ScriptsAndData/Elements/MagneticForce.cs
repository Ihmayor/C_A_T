using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour
{
    private bool isPushing = false;
    private GameObject player;
    public string playerObjName = "Player";
    [Header("Indicates how hard it is to prevent players from falling off tower")]
    public float repelForce = 8.9f;

    void Start()
    {
        player = GameObject.Find(playerObjName);
        
    }

    void Update()
    {
        if (isPushing)
        {
            UpdatePlayerPosition();        
        }
    }

    private void UpdatePlayerPosition()
    {
        Vector3 distance = transform.parent.transform.position - player.transform.position;
        Vector3 repelDistPos = new Vector3(distance.x / repelForce, 0, 0);
        float offBlockOffset = 1.1f;
        bool isOffBlock = Mathf.Abs(distance.x) < offBlockOffset;

        if (isOffBlock)
            player.transform.position += repelDistPos;
        else
            player.transform.position -= repelDistPos;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.name.Contains(playerObjName) && other is BoxCollider2D)
        {
            isPushing = true;                  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.name.Contains(playerObjName) && other is BoxCollider2D)
        {
            isPushing = false;
        }
    }
}
