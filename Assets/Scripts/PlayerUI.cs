using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;
    public Text CoinText;
    public Text MonsterCount;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
        
    }
 

    private void Update()
    {
        display();

        CoinText.text = "COIN : " + GameManager.Instance.Coin;
        MonsterCount.text = "Monster : " + GameManager.Instance.mosterCount;

    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;
    }
}
