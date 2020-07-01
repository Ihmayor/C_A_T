using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<LevelData> levels;

    [SerializeField]
    private LevelDataVariable currentLevel;

    [SerializeField]
    private IntVariable levelNum;
 
    private IntVariable slot1Counter;
    private IntVariable slot2Counter;
    private IntVariable slot3Counter;
    private IntVariable slot4Counter;

    public readonly string GameElementsObjectName = "GameElements";
    public readonly string MainGameObjectName = "MainGame";

    [SerializeField]
    private GameEvent OnBeginLoadLevel;
    [SerializeField]
    private GameEvent OnCompleteLoadLevel;
    [SerializeField]
    private GameEvent OnTotalWin;

    private bool firstLevelLoaded = false;

    void Start()
    {
        slot1Counter = Resources.Load<IntVariable>("ScriptsAndData/Data/ResourceManagement/1_Resource_Num");
        slot2Counter = Resources.Load<IntVariable>("ScriptsAndData/Data/ResourceManagement/2_Resource_Num");
        slot3Counter = Resources.Load<IntVariable>("ScriptsAndData/Data/ResourceManagement/3_Resource_Num");
        slot4Counter = Resources.Load<IntVariable>("ScriptsAndData/Data/ResourceManagement/4_Resource_Num");
   }

    public void LoadFirstLevel()
    {
        levelNum.Value = 0;
        firstLevelLoaded = true;
        if (slot1Counter == null)
            Start();
        currentLevel.Data = levels[0];
        ResetBuffs();
        setAllSlotCounters();
        ResetSlotCounters();
        LoadGameElements();
    }

    private void setAllSlotCounters()
    {
        setSlotCounter(currentLevel.Data.slot1, slot1Counter);
        setSlotCounter(currentLevel.Data.slot2, slot2Counter);
        setSlotCounter(currentLevel.Data.slot3, slot3Counter);
        setSlotCounter(currentLevel.Data.slot4, slot4Counter);
    }

    private void setSlotCounter(BlockElementData slotData, IntVariable slotCounter)
    {
        if (slotData != null)
        {
            slotData.SlotCounter = slotCounter;
        }
    }

    /// <summary>
    /// Deletes previously loaded level and loads the game elements for the current level
    /// </summary>
    public void LoadGameElements()
    {
        OnBeginLoadLevel.Raise();
        //Find Parent in Scene
        GameObject GameElementsObject = GameObject.Find(GameElementsObjectName);
        GameObject MainGameParent = GameObject.Find("MainGame");

        if (GameElementsObject == null)
        {
            //Ensure there is a parent for the game elements
            GameElementsObject = Instantiate(new GameObject(GameElementsObjectName), MainGameParent.transform);
        }
        else if (GameElementsObject.transform.childCount > 0)
        {
            //Clear Old Level Game Elements
            ClearLevel(GameElementsObject);
        }
      

        GameObject levelLoaded = Instantiate(currentLevel.Data.LevelPrefab,GameElementsObject.transform);
        OnCompleteLoadLevel.Raise();
    }

    public void ClearLevel(GameObject GameElementsObject)
    {
        foreach (Transform child in GameElementsObject.transform)
        {
            Destroy(child.gameObject);
        }

    }

    public void RestartLevel()
    {
        ResetSlotCounters();
        LoadGameElements();
    }


    public void LoadNextLevel()
    {
        int nextLevelIndex = currentLevel.LevelNum.Value + 1;
        if (firstLevelLoaded && nextLevelIndex < levels.Count)
        {
            currentLevel.Data = levels[nextLevelIndex];
            currentLevel.LevelNum.Value++;
            setAllSlotCounters();
            ResetSlotCounters();
            ResetBuffs();
            LoadGameElements();
            currentLevel.CoinsCollectedInLevel.Value = 0;
        }
        
    }

    public void CheckTotalWin()
    {
        int nextLevelIndex = currentLevel.LevelNum.Value + 1;
        if (nextLevelIndex >= levels.Count)
        {
            OnTotalWin.Raise();
        } 
       
    }

    private void ResetSlotCounters()
    {
        slot1Counter.Value = 0;
        slot2Counter.Value = 0;
        slot3Counter.Value = 0;
        slot4Counter.Value = 0;
    }
    private void ResetBuffs()
    {
        currentLevel.Data.buff1 = null;
        currentLevel.Data.buff2 = null;
        currentLevel.Data.buff3 = null;
        currentLevel.Data.buff4 = null;
        currentLevel.Data.buff5 = null;
    }


    public void QuitResetValues()
    {
        ResetBuffs();
        ResetSlotCounters();
        currentLevel.LevelNum.Value = 0;

    }

    private void OnApplicationQuit()
    {
        QuitResetValues();
    }

}
