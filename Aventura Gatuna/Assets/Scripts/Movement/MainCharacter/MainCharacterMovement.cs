using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Connection.Instance.GetPosition() != null) { GameObject.FindWithTag("Player").transform.position = Connection.Instance.GetPosition(); }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0) { GetComponent<Animator>().Play("Right"); }
        else if (horizontal < 0) { GetComponent<Animator>().Play("Left"); }
        else if (vertical > 0) { GetComponent<Animator>().Play("Up"); }
        else if (vertical < 0) { GetComponent<Animator>().Play("Down"); }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
