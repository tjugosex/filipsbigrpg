using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{
    public static PlayerMovement Instance;

    public Rigidbody2D body;
    float horizontal;
    float vertical;
    Vector3 direction;
    public float runSpeed = 20.0f;

    private void Start()
    {
        if (isLocalPlayer)
        {
            Instance = this;
        }

    }
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }
    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(0))
        {
            body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;

        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }
}
