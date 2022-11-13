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
        if (Input.GetMouseButtonDown(0))
        {
            if (eventSystem.currentSelectedGameObject.gameObject != null)
            {
                InOut();
            }
        }
    }

    public void InOut()
    {
        
        itemButton = eventSystem.currentSelectedGameObject.gameObject;

        Slot item = itemButton.GetComponent<Slot>();
        Debug.Log(itemButton.transform.parent.gameObject.transform.parent.gameObject.name);
        if (itemButton.transform.parent.gameObject.transform.parent.gameObject == itemBox)
        {
            GameObject itemPouchSlotGrid = itemPouch.transform.GetChild(0).gameObject;
            
            List<string> allItemNames = itemPouchSlotGrid.GetComponent<SlotGrid>().AllItemNames;
            if (allItemNames.Contains(item.Myitem.MyitemName) && item.ItemNum > 0)
            {
                Slot itemIsPouch = itemPouchSlotGrid.transform.Find(item.Myitem.MyitemName).GetComponent<Slot>();
                item.Out();
                itemIsPouch.In();
            }
        }
        else if(itemButton.transform.parent.gameObject.transform.parent.gameObject == itemPouch)
        {
            GameObject itemBoxSlotGrid = itemBox.transform.GetChild(0).gameObject;
            List<string> allItemNames = itemBoxSlotGrid.GetComponent<SlotGrid>().AllItemNames;
            if (allItemNames.Contains(item.Myitem.MyitemName) && item.ItemNum > 0)
            {
                Slot itemIsBox = itemBoxSlotGrid.transform.Find(item.Myitem.MyitemName).GetComponent<Slot>();
                item.Out();
                itemIsBox.In();
            }
        }
    }

    
}
