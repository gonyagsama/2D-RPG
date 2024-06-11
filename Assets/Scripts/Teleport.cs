using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Target;

    void OnTriggerEnter2D(Collider2D collider2d)  // 트리거에 충돌이 되었을 때는 이 함수를 도출한다.
    {
        if (collider2d.gameObject.tag == "Player")
        {
            collider2d.transform.position = Target.position; // 부딪힌 객체를 타겟의 위치로 보낸다.

        }
    }
}
