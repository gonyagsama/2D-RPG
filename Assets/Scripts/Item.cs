using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ok");
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                GameManager.Instance.player.GetComponent<Character>().Speed += 3;
                Debug.Log("Player Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Damage")
            {
                GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage += 5;
                Debug.Log("Player Attack Damage : " + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>());
                Destroy(gameObject);
            }
        }
    }
}
