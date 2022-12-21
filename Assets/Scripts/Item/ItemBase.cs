using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Items", menuName = "Items/item")]
public abstract class ItemBase : ScriptableObject
{
    [Tooltip("�A�C�e����"), SerializeField] string itemName;
    [Tooltip("�A�C�e��image"), SerializeField] Sprite itemImage;

    public string MyitemName { get => itemName;}
    public Sprite MyitemImage { get => itemImage;}

    public abstract void Action();
}
