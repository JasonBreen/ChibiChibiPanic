using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    public Vector3 origin;
    public float step = .4f;
    public LayerMask ground;
    public bool isGrounded;
    private CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(transform.position + origin, step, ground);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = velocity.y;
        velocity = (transform.right * x + transform.forward * z) * speed;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
