using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float Speed = 4f;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }

    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }


}
