using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField]
    private IntVariable PlayerCoinTotal;
    
    
    [SerializeField]
    private IntVariable CurrentLevelNum;

    [SerializeField]
    private Text CoinText;

    [SerializeField]
    private Text LevelText;


    void Update()
    {
        CoinText.text = ""+PlayerCoinTotal.Value;
        LevelText.text = "" + (CurrentLevelNum.Value+1);
    }
}
