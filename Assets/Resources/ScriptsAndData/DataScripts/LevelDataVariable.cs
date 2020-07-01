using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Custom/LevelDataVariable")]
public class LevelDataVariable : ScriptableObject
{
    public LevelData Data;
    public IntVariable LevelNum;
    public IntVariable CoinsCollectedInLevel;
}
