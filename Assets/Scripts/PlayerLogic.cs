using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    Rigidbody rb;

    public float moveForce = 20f;
    public float jumpForce = 7f;

    bool isGrounded = false;

    public Transform startPoint;   
    public float fallLimit = -10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (transform.position.y < fallLimit)
        {
            TeleportToStart();
        }
    }

    void FixedUpdate()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(KeyCode.W)) v = 1;
        if (Input.GetKey(KeyCode.S)) v = -1;
        if (Input.GetKey(KeyCode.A)) h = -1;
        if (Input.GetKey(KeyCode.D)) h = 1;

        Vector3 direction = new Vector3(h, 0, v);
        rb.AddForce(direction * moveForce);
    }

    void TeleportToStart()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPoint.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            isGrounded = true;
        }
    }
}
