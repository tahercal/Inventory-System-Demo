using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool isSlotEmpty;
    [HideInInspector]
    public InventoryItem _item;


    private void Awake()
    {
        isSlotEmpty = false;
    }

    public void SetItemDetails(string itemName, int quantity)
    {
        //Assuming All InventorySlots have items in them from the start
        _item = transform.GetChild(0).GetComponent<InventoryItem>();

        if(_item != null)
        {
            _item.Quantity = quantity;
            _item.itemName.text = itemName;
        }
    }

    public void ReleaseItemFromSlot()
    {
        _item = null;
        isSlotEmpty = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(isSlotEmpty)
        {
            if (eventData.pointerDrag != null)
            {
                isSlotEmpty = false;
                eventData.pointerDrag.transform.SetParent(transform);
                _item = eventData.pointerDrag.GetComponent<InventoryItem>();
                if (_item.hotkeySlotParent != null)
                    _item.hotkeySlotParent.ReleaseItemFromHotkey();
                if (_item.itemSlotParent != null)
                    _item.itemSlotParent.ReleaseItemFromSlot();

                _item.itemSlotParent = this;
            }
        }
    }
}
