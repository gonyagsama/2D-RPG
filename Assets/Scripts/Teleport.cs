using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Target;

    void OnTriggerEnter2D(Collider2D collider2d)  // Ʈ���ſ� �浹�� �Ǿ��� ���� �� �Լ��� �����Ѵ�.
    {
        if (collider2d.gameObject.tag == "Player")
        {
            collider2d.transform.position = Target.position; // �ε��� ��ü�� Ÿ���� ��ġ�� ������.

        }
    }
}
