using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private float jumpForce = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        moveDirection = MoveInput().normalized;
        rb.velocity = (moveDirection * moveSpeed) + (Vector3.up * rb.velocity.y);
        transform.LookAt(transform.position + moveDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            AudioSingleton.Instance.Play("JumpBump");
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > -1.0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -1.0f, rb.velocity.z);
        }


    }

    private Vector3 MoveInput()
    {
        Vector3 output = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            output += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            output += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            output += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            output += Vector3.right;
        }

        return output;
    }

    public void IncreaseSpeed(float multiplier)
    {
        moveSpeed *= multiplier;
        AudioSingleton.Instance.Play("SpeedBoostCollect");
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}
