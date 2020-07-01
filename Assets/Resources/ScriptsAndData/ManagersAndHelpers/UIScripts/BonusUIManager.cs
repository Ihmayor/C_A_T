using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusUIManager : MonoBehaviour
{
    [SerializeField]
    private LevelDataVariable currentLevel;

    public BuffSlot slot1;
    public BuffSlot slot2;
    public BuffSlot slot3;
    public BuffSlot slot4;
    public BuffSlot slot5;


    public void Start()
    {
        OnLevelLoaded();
    }


    /// <summary>
    /// Update Buff/Bonus Slots with relevant data on level load
    /// </summary>
    public void OnLevelLoaded()
    {
        slot1.ChangeBonus(currentLevel.Data.buff1);
        slot2.ChangeBonus(currentLevel.Data.buff2);
        slot3.ChangeBonus(currentLevel.Data.buff3);
        slot4.ChangeBonus(currentLevel.Data.buff4);
        slot5.ChangeBonus(currentLevel.Data.buff5);
    }
}
