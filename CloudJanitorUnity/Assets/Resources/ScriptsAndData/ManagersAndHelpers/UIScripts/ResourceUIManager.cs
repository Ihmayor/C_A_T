using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    /// <summary>
    /// Variables used across teh whole game
    /// </summary>
    [SerializeField]
    private LevelDataVariable currentLevel;
    [SerializeField]
    private ResourceSlotVariable selectedSlot;

    /// <summary>
    /// Resource Slot References in the scene passed through the editor
    /// </summary>
    public ResourceSlot slot1;
    public ResourceSlot slot2;
    public ResourceSlot slot3;
    public ResourceSlot slot4;

    /// <summary>
    /// Used to inform relevant building classes that button building is being triggered
    /// </summary>
    public BooleanVariable isButtonBuilding;

    /// <summary>
    /// Event References to listen for when the flying buff is active
    /// </summary>
    public GameEvent OnFlyBeginEvent;
    public GameEvent OnFlyEndEvent;

    /// <summary>
    /// Keeps track of whether or not a buff is active
    /// </summary>
    private bool isBuffInProgress;
    
    void Start()
    {
        OnLevelLoaded();
    }

    /// <summary>
    /// Updates the appearance of the selected slot and updates the selected slot value
    /// This is deactivated if a buff is in progress
    /// </summary>
    /// <param name="newSlot">Most recently selected resource slot</param>
    public void setSelectedSlot(ResourceSlot newSlot)
    {
        selectedSlot.Value.OnDeslected();
        selectedSlot.Value = newSlot;
        newSlot.OnSelected();

        if (!isBuffInProgress)
             isButtonBuilding.Value = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="setBuffInProgress"></param>
    public void setBuffInProgress(bool setBuffInProgress)
    {
        isBuffInProgress = setBuffInProgress;
    }


    /// <summary>
    /// Triggered when a new level is loaded
    /// </summary>
    public void OnLevelLoaded()
    {
        slot1.gameObject.SetActive(true);
        slot2.gameObject.SetActive(true);
        slot3.gameObject.SetActive(true);
        slot4.gameObject.SetActive(true);

        //Update data for each resource slot
        slot1.ChangeResource(currentLevel.Data.slot1);
        slot2.ChangeResource(currentLevel.Data.slot2);
        slot3.ChangeResource(currentLevel.Data.slot3);
        slot4.ChangeResource(currentLevel.Data.slot4);
        selectedSlot.Value = slot1;
      
        //Default first slot as selected and undo any selection from last level load
        slot1.OnSelected();
        slot2.OnDeslected();
        slot3.OnDeslected();
        slot4.OnDeslected();
    }


}
