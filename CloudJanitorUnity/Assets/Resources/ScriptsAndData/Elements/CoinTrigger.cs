using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{

    [SerializeField]
    private IntVariable CoinTotal;
    
    
    [SerializeField]
    private IntVariable LevelCoinTotal;

    [SerializeField]
    private AudioClip soundEffect;

    [SerializeField]
    private int CoinValue;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            StartCoroutine(WaitForSeconds(0.1f));
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(soundEffect);
            CoinCollected();
        }
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


    public void CoinCollected()
    {
        CoinTotal.Value += CoinValue;
        LevelCoinTotal.Value += CoinValue;
        Destroy(this.gameObject,0.5f);
    }

}
