using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BlockManager:MonoBehaviour
{
    [SerializeField]
    private LevelDataVariable currentLevel;

    [SerializeField]
    private ResourceSlotVariable selectedSlot;

    private BlockElementData tutorialBlock;

    public bool tutorialMode { private set; get; }

    private void Start()
    {
        tutorialMode = false;
        tutorialBlock = Resources.Load<BlockElementData>("ScriptsAndData/Data/Blocks/ShortBlock");
    }

    public void setTutorialMode(bool setMode)
    {
        tutorialMode = setMode;
        DeleteAllBlocks();
    }

    public bool canBuild()
    {
        return selectedSlot.Value.BlockCounter.Value > 0 || tutorialMode;
    }


    public float Build(BlockElementData blockData, Vector3 playerPos)
    {
        return buildBlock(blockData, playerPos);
    }


    public float Build(Vector3 playerPos)
    {
        if (tutorialMode)
        {
            return buildBlock(tutorialBlock, playerPos);
        }
        else
        {
            selectedSlot.Value.BlockCounter.Value--;
            return buildBlock(selectedSlot.Value.Data, playerPos);
        }
    }

    private float buildBlock(BlockElementData blockData, Vector3 playerPos)
    {
        StartCoroutine(createBlock(blockData, playerPos, 0.19f));
        return blockData.playerBlockHeightOffset;
    }

    private IEnumerator createBlock(BlockElementData blockData, Vector3 playerPos, float t)
    {
        GameObject newBlock = Instantiate(blockData.BlockPrefab, playerPos- new Vector3(0,0.1f, 0), Quaternion.identity, this.transform);
        float elapsedTime = 0;
        yield return null;
        Vector3 originalScale = blockData.BlockPrefab.transform.localScale;
        Vector3 startingScale = new Vector3(0.1f, 0.1f, 0.1f);
        if (!blockData.name.Contains("Grow"))
        {
            newBlock.transform.localScale = startingScale;
        }

        while (newBlock.transform.localScale != originalScale)
        {
            newBlock.transform.localScale = Vector3.Lerp(startingScale, originalScale, (elapsedTime / t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void DeleteAllBlocks()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void FreezeAllBlocks()
    {
        foreach (Transform child in transform)
        {
            Rigidbody2D rb2d = child.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.bodyType = RigidbodyType2D.Static;
            }
            else if (child.gameObject.name.Contains("Block") && child.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.name == "Slippery")
            {
                //Removes Slipperiness of Ice Block
                child.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = null;
            }

            Animator stateAnimator = child.gameObject.GetComponent<Animator>();
            if (stateAnimator != null)
            {
                stateAnimator.SetTrigger("Freeze");
            }

        }
    }
    

}
