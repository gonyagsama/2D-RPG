using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager instance;
    public GameObject Backpack_Ui;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemDatas;

    private int defItemUsingCount = 0;
    private int speedItemUsingCount = 0;
    private int powerItemUsingCount = 0;

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

    public void ItemUse()
    {
        int silblngIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        InventoryItemData inventoryItem = InventoryItemDatas[silblngIndex];
        if (inventoryItem == null) return;

        if (inventoryItem.itemID == "HP")
        {
            GameManager.Instance.PlayerHP += 10f;
            GameManager.Instance.PlayerHP = Mathf.Min(GameManager.Instance.PlayerHP, 100f);
            PopupMsgManager.instance.ShowPopupMessage("체력이 10 회복 되었습니다."); 
        }
        else if (inventoryItem.itemID == "MP")
        {

            GameManager.Instance.PlayerMp += 10f;
            GameManager.Instance.PlayerMp = Mathf.Min(GameManager.Instance.PlayerMp, 100f);
            PopupMsgManager.instance.ShowPopupMessage("마나가 10 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "HP_Power")
        {

            GameManager.Instance.PlayerHP += 100f;
            PopupMsgManager.instance.ShowPopupMessage("체력 전체가 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "MP_Power")
        {

            GameManager.Instance.PlayerMp += 100f;
            PopupMsgManager.instance.ShowPopupMessage("마나 전체가 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "Def")
        {
            StartCoroutine(DefItem());
        }
        else if (inventoryItem.itemID == "Speed")
        {
            StartCoroutine(SpeedItem());
        }
        else if (inventoryItem.itemID == "Power")
        {
            StartCoroutine(PowerItem());
        }
        else if (inventoryItem.itemID == "Super")
        {
            //보스전
        }
        else
        {
            Debug.LogError($"존재하지 않는 itemID[{inventoryItem.itemID}]");
            return;
        }

        InventoryItemDatas[silblngIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    }

    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.PlayerDef *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. PlayerDef : " + GameManager.Instance.PlayerDef);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.PlayerDef /= 2;
        if (defItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. PlayerDef : " + GameManager.Instance.PlayerDef);
    }

    IEnumerator SpeedItem()
    {
        defItemUsingCount++;
        GameManager.Instance.Character.Speed *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. Speed : " + GameManager.Instance.Character.Speed);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.Character.Speed /= 2f;
        if (defItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. Speed : " + GameManager.Instance.Character.Speed);
    }

    IEnumerator PowerItem()
    {
        defItemUsingCount++;
        GameManager.Instance.CharacterAttack.AttackDamage *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.CharacterAttack.AttackDamage /= 2f;
        if (defItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
    }
}
