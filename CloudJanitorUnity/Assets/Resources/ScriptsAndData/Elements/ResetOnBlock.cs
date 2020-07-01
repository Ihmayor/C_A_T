using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnBlock : MonoBehaviour
{
    public GameEvent OnCollectedBlock;
    public bool isOnGround = false;
    private bool isCollected = false;

    private GameObject effect;

    private void Start()
    {
        effect = Resources.Load<GameObject>("Prefabs/GameElements/FX/FX_Sparkle_2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Contains("Player"))
        {
            if (collision.gameObject.name.Contains("Ground"))
            {
                if (gameObject.tag == "Untagged")
                {
                    gameObject.tag = "UnCollectable";
                }
                else
                {
                    isOnGround = true;
                }
            }
            else if (collision.gameObject.name.Contains("Block") && gameObject.tag == "Untagged")
            {
                gameObject.tag = "Collectable";
            }
        }
    }

    private void Update()
    {
        if (gameObject.tag == "Collectable" && isOnGround && !isCollected)
        {
            Instantiate(effect, this.transform);
            isCollected = true;
            OnCollectedBlock.Raise();
            Destroy(gameObject,1.5f);
        }
    
    }
}
