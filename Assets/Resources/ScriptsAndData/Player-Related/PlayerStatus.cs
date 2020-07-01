using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{

    [SerializeField]
    private BooleanVariable isKillable;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerRestart;
    public UnityEvent OnPlayerCollect;

    [SerializeField]
    private IntVariable PlayerCoinTotal;
    [SerializeField]
    private IntVariable LevelCoinTotal;

    public void SetKillable(bool canKill)
    {
        isKillable.Value = canKill;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            if (isKillable.Value)
            {
                OnPlayerDeath.Invoke();
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Cloud"))
        {
            OnPlayerCollect.Invoke();
        }
    }
   
    public void RestartDeath()
    {
        isKillable.Value = false;
        OnPlayerRestart.Invoke();
    }

    public void ResetPlayerCoins()
    {
        PlayerCoinTotal.Value -= LevelCoinTotal.Value;
        LevelCoinTotal.Value = 0;
    }

    public void ClearCoins()
    {
        PlayerCoinTotal.Value = 0;
        LevelCoinTotal.Value = 0;

    }

    private void OnApplicationQuit()
    {
        isKillable.Value = false;
        ClearCoins();
    }

}
