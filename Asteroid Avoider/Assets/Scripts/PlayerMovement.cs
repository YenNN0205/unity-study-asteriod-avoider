using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody rb;
    private Vector3 movementDirection;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxForce;
    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInput();
        KeepingPlayerOnScreen();
        RotatePlayerFaceToVelocity();
    }
    private void FixedUpdate()
    {
        //Add force to player to movement
        if(movementDirection == Vector3.zero)
        {
            return;
        }
        rb.AddForce(forceMagnitude*movementDirection, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxForce);
    }
    //Get force to player thourought Input System
    private void ProcessInput()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
        Vector3 touchScreen = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchScreen);
        movementDirection = worldPos - transform.position;
        movementDirection.z = 0f;
        movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }
    //Make player always onscreen
    private void KeepingPlayerOnScreen()
    {
        Vector3 oppositePos = transform.position;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        if(viewportPos.x > 1)
        {
            oppositePos.x = -oppositePos.x + 0.1f;
        }
        else if(viewportPos.x < 0)
        {
            oppositePos.x = -oppositePos.x - 0.1f;
        }
        if(viewportPos.y > 1)
        {
            oppositePos.y = -oppositePos.y + 0.1f;
        }
        else if(viewportPos.y < 0)
        {
            oppositePos.y = -oppositePos.y - 0.1f;
        }
        transform.position = oppositePos;
    }
    private void RotatePlayerFaceToVelocity()
    {
        if(rb.velocity == Vector3.zero) {return;}
        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        Quaternion currentRotation = rb.rotation;
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotateSpeed*Time.deltaTime);
    }

}
