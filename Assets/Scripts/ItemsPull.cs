using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPull : Manager<ItemsPull>
{
    [SerializeField] GameObject item;
    [SerializeField] List<ItemData> types;
    int index;
    int size;
    public GameObject[] items;

    /// <summary>
    /// Initializes pull of specified size
    /// </summary>
    /// <param name="size">size of pull</param>
    public void Init(int size)
    {
        this.size = size;
        index = 0;
        items = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            items[i] = Instantiate(item,transform);
            items[i].SetActive(false);
        }
    }

    /// <summary>
    /// Returns item with random ItemData
    /// </summary>
    /// <returns></returns>
    public GameObject GetItem()
    {
        if (items == null)
            return null;
        var tmp = items[index];
        tmp.SetActive(true);
        tmp.GetComponent<Item>().data = types[Random.Range(0, types.Count)];
        tmp.GetComponent<Item>().ResetItem();
        index++;
        if (index == size)
            index = 0;
        return tmp;
    }
}
