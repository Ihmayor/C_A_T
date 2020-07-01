using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Custom/BonusData")]
public class BonusData : ScriptableObject
{
    public int CooldownTime;
    public int Price;
    public string Name;
    public GameObject Prefab;
    public Sprite IconImage;
    public GameEvent StartBuffEvent;
    public GameEvent EndBuffEvent;
}
