using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject blockUI;

    public GameEventListener CloudSuckListener;
    void Start()
    {
       blockUI = GameObject.Find("BlockNum");
    }

    public void UpdateDisplayUI(BlockElementData blockData)
    {

    }


    internal void UpdateCloudCounter(int counter)
    {
        blockUI.GetComponent<Text>().text = "Debug Blocks #: " + counter;
    }
}
