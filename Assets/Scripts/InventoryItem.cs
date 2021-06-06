using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Text quantityText;

    public Text itemName;
    [HideInInspector]
    public int hotkey_SlotNumber;
    [HideInInspector]
    public HotkeySlot hotkeySlotParent;
    [HideInInspector]
    public ItemSlot itemSlotParent;

    private CanvasGroup canvasGroup;

    public int Quantity 
    { 
        get { return quantity; } 
        set { quantity = value; quantityText.text = value.ToString(); } 
    }

    private void Start()
    {
        //Assuming all items are initially in their inventory slots
        itemSlotParent = transform.parent.GetComponent<ItemSlot>();
        canvasGroup = GetComponent<CanvasGroup>();
        hotkeySlotParent = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (itemSlotParent != null)
            transform.position = itemSlotParent.transform.position;
        else
            transform.position = hotkeySlotParent.transform.position;

    }
}
