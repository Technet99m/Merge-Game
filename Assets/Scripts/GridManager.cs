using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Manager<GridManager>
{
    [SerializeField] int size;
    [SerializeField] GameObject Cell;
    List<Cell> cells;
    void Start()
    {
        cells = new List<Cell>();
        for (int i = 0; i < size * size; i++)
        {
            cells.Add(Instantiate(Cell, transform).GetComponent<Cell>());
            cells[i].index = i;
        }
        ItemsPull.instance.Init(size * size);
    }

    public void SpawnNewItem()
    {
        // Check if there is empty slot
        bool hasEmpty = false;
        foreach (var cell in cells)
        {
            if (cell.item == null)
            {
                hasEmpty = true;
                break;
            }
        }
        if (!hasEmpty)
            return;

        // Choose slot for item
        int i;
        while(true)
        {
            i = Random.Range(0, cells.Count);
            if (cells[i].item == null)
                break;
        }

        // Get Item
        var item = ItemsPull.instance.GetItem();
        cells[i].item = item.GetComponent<Item>();
        item.GetComponent<Item>().indexOfCell = i;
        item.transform.position = cells[i].transform.position;
    }

    public void SetToNearestCell(Item item)
    {
        int minIndex = 0;
        float minDistance = float.PositiveInfinity;
        for(int i = 0;i<cells.Count;i++)
        {
            if (Vector3.Distance(item.transform.position, cells[i].transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(item.transform.position, cells[i].transform.position);
                minIndex = i;
            }
        }
        Cell Nearest = cells[minIndex];
        if (Nearest.item == null)
        {

            item.indexOfCell = Nearest.index;
            Nearest.item = item;
            item.transform.position = Nearest.transform.position;
        }
        else if (Nearest.item.Equals(item))
        {
            cells[item.indexOfCell].item = null;
            item.gameObject.SetActive(false);
            Nearest.item.NextStage();
        }
        else
            item.transform.position = cells[item.indexOfCell].transform.position;
    }

    public void EmptyCell(int index)
    {
        cells[index].item = null;
    }
}
