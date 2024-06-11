using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectUI : MonoBehaviour
{
    public Text MainTxt;

    void Start()
    {
        MainTxt.text = GameManager.Instance.UserID;
    }
}
