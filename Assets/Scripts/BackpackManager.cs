using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager instance;
    public GameObject Backpack_Ui;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemDatas;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        InventoryItemDatas = new InventoryItemData[ItemImages.Length];
    }

    void Update()
    {
        BackpackUiOn();
        CoinText.text = $"Coin: {GameManager.Instance.Coin:N0}";
    }

    private void BackpackUiOn()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Backpack_Ui.SetActive(!Backpack_Ui.activeSelf);
        }
    }

    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < ItemImages.Length; i++)
        {
            if (ItemImages[i].sprite == null)
            {
                ItemImages[i].sprite = item.itemImage;
                InventoryItemDatas[i] = item;
                return true;
            }
        }
        return false;
    }
}
