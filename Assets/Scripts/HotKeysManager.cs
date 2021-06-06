using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeysManager : MonoBehaviour
{
    [SerializeField]
    private List<HotkeySlot> hotkeysList = new List<HotkeySlot>();
    private InventoryItem _item;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseItem(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            UseItem(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            UseItem(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            UseItem(4);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            UseItem(5);
    }

    private void UseItem(int itemNumber)
    {
        //List starts from 0
        if (!hotkeysList[itemNumber - 1].isHotKeySlotEmpty)
        {
            _item = hotkeysList[itemNumber - 1]._item;
            _item.Quantity--;

            //Delete Item if its quantity is less than 0
            if (_item.Quantity <= 0)
            {
                hotkeysList[itemNumber - 1].ReleaseItemFromHotkey();
                Destroy(_item.gameObject);
            }
        }
    }
}
