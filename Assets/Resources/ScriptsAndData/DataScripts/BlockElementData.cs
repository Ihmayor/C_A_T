using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Custom/BlockElementData")]
public class BlockElementData : ScriptableObject
{
    public string BlockName;
    public GameObject BlockPrefab;
    public Sprite Icon;
    public Color FontColor;
    public Color FontShadowColor;
    public Sprite Cloud;
    public float playerBlockHeightOffset = 0.80f;
    public IntVariable SlotCounter;
    public Sprite Indicator;
}
