using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] ItemBase itembase;
    [SerializeField] Image itemImage;
    [SerializeField] Text itemNumText;
    [SerializeField] int itemNum;

    
    public ItemBase Myitem { get => itembase; private set => itembase = value; }
    public int ItemNum { get => itemNum; set => itemNum = value; }

    private void Update()
    {
        if(ItemNum == 0)
        {
            itemImage.color = Color.clear;
            itemNumText.text = $"";
        }
        else 
        {
            itemImage.color = Color.white;
        }
    }
    public void SetItem(ItemBase item)
    {
        if(item != null)
        {
            itembase = item;
            itemImage.color = Color.white;
            itemImage.sprite = item.MyitemImage;
            gameObject.name = $"{item.MyitemName}";
            itemNumText.text = $"~{itemNum}";
        }
        else
        {
            itemNum = 0;
            itemImage.color = Color.clear;
            itemNumText.text = $"";
        }
    }

    /// <summary>item‚Ì”‚ğ‘‚â‚µ‚Ü‚·</summary>
    public void In()
    {
        Debug.Log("ŒÄ‚Î‚ê‚Ü‚µ‚½");
        itemNum++;
        itemNumText.text = $"~{itemNum}";
    }
    
    /// <summary>item‚Ì”‚ğŒ¸‚ç‚µ‚Ü‚·</summary>
    public void Out()
    {
        itemNum--;
        itemNumText.text = $"~{itemNum}";
    }
}
