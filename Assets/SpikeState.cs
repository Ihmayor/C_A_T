using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeState : MonoBehaviour
{

    [SerializeField]
    private BooleanVariable isKillable;

    private SpriteRenderer spikeSprite;
    void Start()
    {
        spikeSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKillable.Value)
        {
            spikeSprite.color = new Color(spikeSprite.color.r, spikeSprite.color.g, spikeSprite.color.b, 1);
        }
        else 
        {
            spikeSprite.color = new Color(spikeSprite.color.r, spikeSprite.color.g, spikeSprite.color.b, 0);
        }
    }
}
