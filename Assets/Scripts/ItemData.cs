using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item",menuName = "Item",order = 51)]
public class ItemData : ScriptableObject
{
    public Sprite[] sprites;
    public string ID;
}
