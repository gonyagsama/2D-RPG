using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject PotionUI,PowerUI, BattleUI;
    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                if (hit.collider.gameObject.name == "PowerNpc")
                {
                    PowerUI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "PotionNpc")
                {
                    PotionUI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNpc")
                {
                    BattleUI.SetActive(true);
                }
            }
        }
    }
}
