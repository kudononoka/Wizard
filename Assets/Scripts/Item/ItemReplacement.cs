using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
public class ItemReplacement : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject itemBox;
    [SerializeField] GameObject itemPouch;

    GameObject itemButton;
    public void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //UIの押されたButtonのオブジェクトがNullじゃなかったら取得
        //    if (eventSystem.currentSelectedGameObject.gameObject != null)
        //    {
        //        Replacement();
        //    }
        //}
    }

    public void Replacement()
    {
        
        itemButton = eventSystem.currentSelectedGameObject.gameObject;

        Slot item = itemButton.GetComponent<Slot>();

        //押されたButtonのGameObjectの親親オブジェクトがItemBoxの場合→ItemPouchに属する同じGameObject名のitemの数が増え、ItemBoxのitemの数が減る
        
        if (itemButton.transform.parent.gameObject.transform.parent.gameObject == itemBox)
        {
            ItemInOut(itemPouch, item);
        }
        //ItemPouchの場合→ItemBoxに属する同じGameObject名のitemの数が増え、ItemPouchのitemの数が減る
        else if (itemButton.transform.parent.gameObject.transform.parent.gameObject == itemPouch)
        {
            ItemInOut(itemBox, item);
        }
    }

    public void ItemInOut(GameObject itemGoToWhere, Slot item)
    {
        GameObject itemSlotGrid = itemGoToWhere.transform.GetChild(0).gameObject;

        //SlotGridにあるItemの名前のListを取得
        List<string> allItemNames = itemSlotGrid.GetComponent<SlotGrid>().AllItemNames;
        //もう一つのSlotGridに同じitem名がありかつ自身のItemの数が０以上の時自身のitem数を-1し、反対のitemに+1します
        if (allItemNames.Contains(item.Myitem.MyitemName) && item.ItemNum > 0)
        {
            Slot itemIsGoTo = itemSlotGrid.transform.Find(item.Myitem.MyitemName).GetComponent<Slot>();
            item.Out(); 
            itemIsGoTo.In();　
        }
    }

    
}
