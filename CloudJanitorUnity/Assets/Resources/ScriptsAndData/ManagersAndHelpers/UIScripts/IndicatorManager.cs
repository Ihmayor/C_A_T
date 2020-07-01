using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IndicatorManager : MonoBehaviour
{

    [SerializeField]
    private ResourceSlotVariable selectedSlot;

    [SerializeField]
    private GameObject indicator;
    void FixedUpdate()
    {
        bool notTouchingUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.touchCount > 0 && notTouchingUI && selectedSlot.Value != null && selectedSlot.Value.Data != null)
        {
            BlockElementData selectedData = selectedSlot.Value.Data;
            indicator.GetComponent<SpriteRenderer>().sprite = selectedData.Indicator;
            indicator.SetActive(true);
        }
    }
}
