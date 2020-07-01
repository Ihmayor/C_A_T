using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Custom/LevelData")]
public class LevelData : ScriptableObject
{
    public int LevelNumber;
    public Sprite BackgroundImage;

    public GameObject LevelPrefab;
    public Vector2 playerStartPosiiton;

    public BlockElementData slot1 = null;
    public BlockElementData slot2 = null;
    public BlockElementData slot3 = null;
    public BlockElementData slot4 = null;

    public BonusData buff1 = null;
    public BonusData buff2 = null;
    public BonusData buff3 = null;
    public BonusData buff4 = null;
    public BonusData buff5 = null;
}
