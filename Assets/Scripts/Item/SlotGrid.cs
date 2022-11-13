using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
    [SerializeField] GameObject slotPrefab;

    [SerializeField] int sloatNumber = 20;

    [SerializeField] ItemBase[] allItem;

    List<string> allItemNames = new List<string>();
    public ItemBase[] AllItems { get { return allItem; } }
    public List<string> AllItemNames { get { return allItemNames; } }
    private void Start()
    {
        
        for(int i = 0; i < sloatNumber; i++)
        {
            GameObject slotGo = Instantiate(slotPrefab, this.transform);

            Slot slot = slotGo.GetComponent<Slot>();

            if(i < allItem.Length)
            {
                slot.SetItem(allItem[i]);
                allItemNames.Add(allItem[i].MyitemName);
                Debug.Log(AllItemNames[i]);
            }
            else
            {
                slot.SetItem(null);
            }
        }
    }
}
