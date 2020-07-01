using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoin : MonoBehaviour
{
    [SerializeField]
    private IntVariable PlayerCoinTotal;

    public void IncreaseValue(int value)
    {
        if (PlayerCoinTotal.Value + value <= 99)
        {
            PlayerCoinTotal.Value += value;
        }
        else
        {
            PlayerCoinTotal.Value = 99;
        }
    }

    private void LateUpdate()
    {
        if (PlayerCoinTotal.Value >= 99)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }

    }
}
