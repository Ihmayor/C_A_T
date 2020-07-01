using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    public BlockElementData Data;
    public IntVariable BlockCounter;

    [SerializeField]
    private Text BlockNum;
    [SerializeField]
    private Text BlockShadowNum;
    [SerializeField]
    private Image ResourceImage;

    void Update()
    {
        BlockNum.text = "" + BlockCounter.Value;
        BlockShadowNum.text = "" + BlockCounter.Value;
    }

    public void OnSelected()
    {
        ResourceImage.color = new Color(ResourceImage.color.r,
                                        ResourceImage.color.g,
                                        ResourceImage.color.b,
                                        1f); 
    }

    public void OnDeslected()
    {
        ResourceImage.color = new Color(ResourceImage.color.grayscale,
                                        ResourceImage.color.grayscale,
                                        ResourceImage.color.grayscale,
                                        0.5f);
    }

    public void ChangeResource(BlockElementData data)
    {
        if (data == null)
            this.gameObject.SetActive(false);
        else
        {
            this.gameObject.SetActive(true);
            Data = data;
            ResourceImage.sprite = Data.Icon;
            BlockNum.color = new Color(data.FontColor.r, data.FontColor.g, data.FontColor.b,BlockNum.color.a);
            BlockShadowNum.color = new Color(data.FontShadowColor.r, data.FontShadowColor.g, data.FontShadowColor.b, BlockShadowNum.color.a);
        }
    }


}
