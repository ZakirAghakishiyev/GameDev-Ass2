using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    Rigidbody rb;

    Vector3 startPos = new Vector3(2.19f, 1.36f, -2.04f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TeleportToStart();
            Debug.Log("Game Over");
        }
    }

    void TeleportToStart()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPos;
    }
}
