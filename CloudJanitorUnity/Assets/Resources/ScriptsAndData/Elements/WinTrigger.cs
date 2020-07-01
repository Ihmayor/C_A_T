using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public readonly string WinCanvasName = "WinScreen";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerWin();
    }
    public void TriggerWin()
    {
        GetComponent<Animator>().SetTrigger("Triggered");
        //Win Canvas Must be Enabled to Trigger This. Disabled Game Objects are unable to listen to events.
        GameObject.Find(WinCanvasName).transform.Find("WinElements").gameObject.SetActive(true);
        if (GameObject.Find("HeadsUpDisplay") != null)
            GameObject.Find("HeadsUpDisplay").SetActive(false);

        //Prevent Player from dying after winning
        GameObject.Find("Player").GetComponent<PlayerStatus>().RestartDeath();

        //Check if game is beaten.
        GameObject.Find("BackendManagers").GetComponent<LevelManager>().CheckTotalWin();
    }
}
