using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPurchase : MonoBehaviour
{
    [SerializeField]
    private IntVariable PlayerCoinTotal;

    [SerializeField]
    private LevelDataVariable currentLevelDataReference;

    [SerializeField]
    private BonusData buffData;

    [SerializeField]
    private Image buffImage;


    private bool hasPurchased = false;

    private void Start()
    {
        ResetBuffs();
    }

    public void Update()
    {
        if (buffData != null && PlayerCoinTotal.Value < buffData.Price)
        {
            GetComponent<Button>().interactable = false;
        }
        else if (!hasPurchased)
        {
            buffImage.color = new Color(buffImage.color.r, buffImage.color.g, buffImage.color.b, 0.5f);
            GetComponent<Button>().interactable = true;
        }
    }

    public void ResetBuffs()
    {
        Debug.Log("resetting buffs");
        hasPurchased = false;
        buffImage.color = new Color(buffImage.color.r, buffImage.color.g, buffImage.color.b, 0.5f);
    }

    public void AddBuffToLevel()
   {
        hasPurchased = true;    
        PlayerCoinTotal.Value -= buffData.Price;
        buffImage.color = new Color(buffImage.color.r, buffImage.color.g, buffImage.color.b, 1);
        LevelData currLevel = currentLevelDataReference.Data;
        if (currLevel.buff1 == null)
        {
            currLevel.buff1 = buffData;
        }
        else if (currLevel.buff2 == null)
        {
            currLevel.buff2 = buffData;
        }
        else if (currLevel.buff3 == null)
        {
            currLevel.buff3 = buffData;
        }
        else if (currLevel.buff4 == null)
        {
            currLevel.buff4 = buffData;
        }
        else if (currLevel.buff5 == null)
        {
            currLevel.buff5 = buffData;
        }
    }
}
