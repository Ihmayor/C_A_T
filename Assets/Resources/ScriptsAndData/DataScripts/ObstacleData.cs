using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Custom/Obstacle")]
public class ObstacleData : ScriptableObject
{
    public string Name;
    public string LayerAffect;
    public GameObject Prefab;
}
