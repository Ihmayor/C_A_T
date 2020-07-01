using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffSlot : MonoBehaviour
{
    public BonusData Data;//Data of Buff/Bonus
    public Image BuffImage;//Icon Image of Bonus.Buff
    private int timeLeft; //Seconds Overall
    public Text countdown; //UI Text Object

    void Start()
    {
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    /// <summary>
    /// Changes the BonusData for the buff slot
    /// </summary>
    /// <param name="data">Contains all the information related to a buff bonus</param>
    public void ChangeBonus(BonusData data)
    {
        //Deactivate Icon if No Bonuses Loaded for Level
        if (data == null)
            this.gameObject.SetActive(false);
        else
        {
            //Reactive Icon if Bonuses are Loaded For Level
            this.gameObject.SetActive(true);
            
            //Load New Data
            Data = data;
            BuffImage.sprite = Data.IconImage;
            timeLeft = data.CooldownTime;

            //Handle processes that might have been interrupted by triggered level loading
            StopCoroutine("LoseTime");
            if (Data.EndBuffEvent != null)
                Data.EndBuffEvent.Raise();
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }


    /// <summary>
    /// Trigger all processes related to activating a buff
    /// </summary>
    public void ActivateBuff()
    {
        //Trigger Listeners of Buff Event
        Data.StartBuffEvent.Raise();

        //Trigger Countdown
        StartCoroutine("LoseTime");
    }

    void Update()
    {
        //Update The Coundown timer.
        if (countdown != null && Data != null)
        {
            countdown.text = ("" + timeLeft);
            if (timeLeft == 0)
            {
                //Re-enable buff button and send end of buff event to all relevant listeners
                timeLeft = Data.CooldownTime;
                if (Data.EndBuffEvent != null)
                    Data.EndBuffEvent.Raise();
                GetComponent<Button>().interactable = true;
            }
        }
    }

    
    /// <summary>
    /// Coroutine to handle the Countdown Timer
    /// </summary>
    /// <returns>Ienumerator as required by coroutines</returns>
    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            //Disable Button so that even cannot be triggered overlapping
            GetComponent<Button>().interactable = false;
            //Wait before decreasing time left
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }


}
