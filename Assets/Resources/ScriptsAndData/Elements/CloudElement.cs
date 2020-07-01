using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudElement : MonoBehaviour
{

    internal AudioClip SuckingSound;

    [SerializeField]
    private GameEvent OnBlockCollected;

    private Animator AnimController;
    private bool hasEntered = false;
    void Start()
    {
        SuckingSound = GetComponent<AudioSource>().clip;
        AnimController = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision is BoxCollider2D && 
            collision.gameObject.name.Contains("Player") &&
            !hasEntered)
        {
            hasEntered = true;
            GetComponent<AudioSource>().PlayOneShot(SuckingSound);
            if (AnimController != null)
                AnimController.SetTrigger("Sucked");

            StartCoroutine("DelayCloudSuckTrigger"); 
            Destroy(gameObject, 1.1f);
        }
    }
    private IEnumerator DelayCloudSuckTrigger()
    {
         yield return new WaitForSeconds(0.8f);
          OnBlockCollected.Raise();
    }

}
