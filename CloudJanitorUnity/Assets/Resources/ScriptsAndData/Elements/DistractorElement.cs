using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractorElement : MonoBehaviour
{
    [SerializeField]
    private GameObject DistractorAnimation;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            float randomOffset = Random.Range(0.05f, 0.8f);
            StartCoroutine(DelayDistractorAnimation(randomOffset));
        }
    }

    IEnumerator DelayDistractorAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DistractorAnimation.SetActive(true);
    }

}
