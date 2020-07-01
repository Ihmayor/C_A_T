using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUIManager : MonoBehaviour
{
    public Text CoinCounter;

    [SerializeField]
    private IntVariable CoinTotal;

    public void Start()
    {
        CoinCounter.text = "" + CoinTotal.Value;
    }

    public void Update()
    {
        CoinCounter.text = "" + CoinTotal.Value;
    }

}
