using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P : MonoBehaviour
{

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * moveSpeed;
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);

        // Turning
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX * turnSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
}
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
