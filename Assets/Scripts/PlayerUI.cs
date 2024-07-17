using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;
    public Text LvText;

    public Slider HpSlider;
    public Slider MPSlider;
    public Slider ExpSlider;

    private GameObject player;
    //public GameObject spawnPos;

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        GameObject spawnPos = GameObject.FindGameObjectWithTag("initPos");
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
        
    }
 

    private void Update()
    {
        display();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerStat.PlayerHP;
        MPSlider.value = GameManager.Instance.PlayerStat.PlayerMp;
        ExpSlider.value = GameManager.Instance.PlayerStat.PlayerExp;
        LvText.text = "Lv : " + GameManager.Instance.PlayerStat.Level;
    }
}
