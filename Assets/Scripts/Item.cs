using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public ItemData data;
    public int stage;
    public int indexOfCell;


    #region Dragging
    Vector3 offset;
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = Input.mousePosition - transform.position;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GridManager.instance.SetToNearestCell(this);
    }
    public  bool Equals(Item other)
    {
        return stage == other.stage && data.ID == other.data.ID;
    }
    #endregion
    private void Start()
    {
        ResetItem();
    }
    public void ResetItem()
    {
        stage = 0;
        GetComponent<Image>().sprite = data.sprites[stage];
    }
    public void NextStage()
    {
        stage++;
        if(stage==2)
        {
            ScoreManager.instance.AddScore();
            GridManager.instance.EmptyCell(indexOfCell);
            gameObject.SetActive(false);
            return;
        }
        GetComponent<Image>().sprite = data.sprites[stage];
    }


}
