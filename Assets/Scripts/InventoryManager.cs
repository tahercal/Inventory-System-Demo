using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private List<ItemDetails> itemDetailsList = new List<ItemDetails>();
    [SerializeField]
    private List<ItemSlot> itemSlotList = new List<ItemSlot>();

    private void Start()
    {
        //Populate Inventory Item Names and Quantities as defined in the inspector
        PopulateInventory();
    }

    private void PopulateInventory()
    {
        if(itemSlotList.Count > 0)
        {
            for (int i = 0; i < itemSlotList.Count; i++)
            {
                itemSlotList[i].SetItemDetails(itemDetailsList[i].itemName, itemDetailsList[i].itemQuantity);
            }
        }
    }

    void Update()
    {
        //Toggle Inventory Panel
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeInHierarchy)
                inventoryPanel.SetActive(false);
            else
                inventoryPanel.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    [System.Serializable]
    public struct ItemDetails
    {
        public string itemName;
        public int itemQuantity;
    }
}
