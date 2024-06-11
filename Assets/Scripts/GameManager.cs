using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    private GameObject player;

    public float PlayerHP = 100f; //체력
    public float PlayerExp = 1f; //경험치
    public int Coin = 0;
    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {

            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }
}
