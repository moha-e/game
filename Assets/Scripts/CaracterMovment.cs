using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CaracterMovment : MonoBehaviour
{
    
    public float speed = 20;
    public float rotationSpeed = 360;
    public float jumpForce = 10;
    public float sprint = 1f;
    public float finalspeed;   
    private new Rigidbody rigidbody;
    private float verticalValue, horizontalValue, mouseX, mouseY;
    private Vector3 rotationVector;
   

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        verticalValue = Input.GetAxis("Vertical");
        horizontalValue = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Move();
        Rotate();
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.CapsLock)) 
        {
            sprint = 1.9f;
            
        }
        else 
        {
            sprint = 1;
            finalspeed = speed * sprint;
        }

    }
    private void Move() 
    {
        Vector3 targetPosition = (transform.forward * verticalValue + transform.right * horizontalValue ) * speed * sprint * Time.fixedDeltaTime; 
        rigidbody.MovePosition(transform.position + targetPosition);
        targetPosition.y = 0;
    }
    private void Rotate()
    {
        rotationVector += new Vector3(-mouseY, mouseX, 0) * rotationSpeed * Time.fixedDeltaTime;
        rotationVector.x=Mathf.Clamp(rotationVector.x,-45,45);

        transform.rotation=Quaternion.Euler(rotationVector);
    }
    private void Jump()
    {
        rigidbody.AddForce(new Vector3(0,jumpForce,0), ForceMode.Force );
    }
}
