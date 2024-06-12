using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private void Awake()
    {
        Instance = this;
    }

    //ī�޶� ����
    public float ShakeAmount;
    float ShakeTime;
    Vector3 initialPosition;
    private void Start()
    {
        //VibrateForTime(3);
    }

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    private void Update()
    {
        initialPosition = GameObject.FindWithTag("MainCamera").transform.position;//ī�޶� ��鸱 ��ġ��
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
}
