using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotkeySlot : MonoBehaviour, IDropHandler
{
    public int hotKeyNumber;
    public bool isHotKeySlotEmpty;
    [HideInInspector]
    public InventoryItem _item;

    private void Start()
    {
        _item = null;
        //Assuming Hotkey slots are initially empty
        isHotKeySlotEmpty = true;
    }

    public void ReleaseItemFromHotkey()
    {
        _item = null;
        isHotKeySlotEmpty = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isHotKeySlotEmpty)
        {
            if (eventData.pointerDrag != null)
            {
                isHotKeySlotEmpty = false;
                eventData.pointerDrag.transform.SetParent(transform);
                _item = eventData.pointerDrag.GetComponent<InventoryItem>();
                _item.hotkey_SlotNumber = hotKeyNumber;
                if (_item.itemSlotParent != null)
                    _item.itemSlotParent.ReleaseItemFromSlot();
                if (_item.hotkeySlotParent != null)
                    _item.hotkeySlotParent.ReleaseItemFromHotkey();

                _item.itemSlotParent = null;
                _item.hotkeySlotParent = this;
            }
        }
    }
}
