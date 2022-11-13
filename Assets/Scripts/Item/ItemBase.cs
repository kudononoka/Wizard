using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Items", menuName = "Items/item")]
public class ItemBase : ScriptableObject
{
    [Tooltip("アイテム名"), SerializeField] string itemName;
    [Tooltip("アイテムimage"), SerializeField] Sprite itemImage;

    public string MyitemName { get => itemName;}
    public Sprite MyitemImage { get => itemImage;}

}
