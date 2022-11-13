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
            itemNumText.text = $"Å~{itemNum}";
        }
        else
        {
            itemNum = 0;
            itemImage.color = Color.clear;
            itemNumText.text = $"";
        }
    }

    public void In()
    {
        Debug.Log("åƒÇŒÇÍÇ‹ÇµÇΩ");
        itemNum++;
        itemNumText.text = $"Å~{itemNum}";
    }
    
    public void Out()
    {
        itemNum--;
        itemNumText.text = $"Å~{itemNum}";
    }
}
