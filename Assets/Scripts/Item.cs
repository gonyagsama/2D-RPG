using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "coin")
            {
                GameManager.Instance.coin += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
        }
    }
}
