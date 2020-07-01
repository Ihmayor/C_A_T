using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
 public class CloudManager:MonoBehaviour
{
    [SerializeField]
    private LevelDataVariable currentLevel;

    private BlockElementData slot1;
    private BlockElementData slot2;
    private BlockElementData slot3;
    private BlockElementData slot4;
        
    public void Start()
    {
        ChangeResource();
    }


    //Listen for new Level Event
    public void ChangeResource()
    {
        slot1 = currentLevel.Data.slot1;
        slot2 = currentLevel.Data.slot2;
        slot3 = currentLevel.Data.slot3;
        slot4 = currentLevel.Data.slot4;
    }

    public void CloudCollected(BlockElementData data)
    {
        //Keep all resources up to date constantly
        ChangeResource();

        //Increase relevant resource slot counter
        if (data.BlockName == slot1.BlockName)
        {
            slot1.SlotCounter.Value++;
        }
        else if (data.BlockName == slot2.BlockName) {
            slot2.SlotCounter.Value++;
        }
        else if (data.BlockName == slot3.BlockName)
        {
            slot3.SlotCounter.Value++;
        }
        else if (data.BlockName == slot4.BlockName)
        {
            slot4.SlotCounter.Value++;
        }
        else
        {
            Debug.Log("ERROR! Collected Cloud not in Resource Slots!!!");
        }

    }

}
