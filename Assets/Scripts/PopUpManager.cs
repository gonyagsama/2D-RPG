using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    System.Action _OnClickConformButton, _OnClickCancelButton;

    private static PopUpManager _instance;
    public static PopUpManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject _popup; 
    public Text _popMsg;

    public void Open(string text,
System.Action OnClickConformButton, System.Action OnClickCancelButton)
    {
        _popup.SetActive(true);
        _popMsg.text = text;
        _OnClickConformButton = OnClickConformButton;
        _OnClickCancelButton = OnClickCancelButton;
    }

    public void Close()
    {
        _popup.SetActive(false);
    }

    private void Awake()
    {
        _popup.SetActive(false); 
        DontDestroyOnLoad(this); 
        _instance = this; 
    }

    public void OnClickConformButton()
    {
        if (_OnClickConformButton != null)
        {
            Debug.Log("Ȯ�� ��ư ����");
            _OnClickConformButton(); 
        }
        Close(); 
    }

    public void OnClickCancelButton()
    {
        if (_OnClickCancelButton != null)
        {
            Debug.Log("��� ��ư ����");
            _OnClickCancelButton();
        }
        Close();
    }

}

