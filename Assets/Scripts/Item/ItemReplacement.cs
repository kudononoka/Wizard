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
        //    //UI�̉����ꂽButton�̃I�u�W�F�N�g��Null����Ȃ�������擾
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

        //�����ꂽButton��GameObject�̐e�e�I�u�W�F�N�g��ItemBox�̏ꍇ��ItemPouch�ɑ����铯��GameObject����item�̐��������AItemBox��item�̐�������
        
        if (itemButton.transform.parent.gameObject.transform.parent.gameObject == itemBox)
        {
            ItemInOut(itemPouch, item);
        }
        //ItemPouch�̏ꍇ��ItemBox�ɑ����铯��GameObject����item�̐��������AItemPouch��item�̐�������
        else if (itemButton.transform.parent.gameObject.transform.parent.gameObject == itemPouch)
        {
            ItemInOut(itemBox, item);
        }
    }

    public void ItemInOut(GameObject itemGoToWhere, Slot item)
    {
        GameObject itemSlotGrid = itemGoToWhere.transform.GetChild(0).gameObject;

        //SlotGrid�ɂ���Item�̖��O��List���擾
        List<string> allItemNames = itemSlotGrid.GetComponent<SlotGrid>().AllItemNames;
        //�������SlotGrid�ɓ���item�������肩���g��Item�̐����O�ȏ�̎����g��item����-1���A���΂�item��+1���܂�
        if (allItemNames.Contains(item.Myitem.MyitemName) && item.ItemNum > 0)
        {
            Slot itemIsGoTo = itemSlotGrid.transform.Find(item.Myitem.MyitemName).GetComponent<Slot>();
            item.Out(); 
            itemIsGoTo.In();�@
        }
    }

    
}
