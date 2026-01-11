using System;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] CinemachineCamera playerCamera;
    [SerializeField] float speed = 5f;
    Rigidbody rb;
    PlayerAnimations animations;
    Vector3 movement;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<PlayerAnimations>();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void OnMove()
    {
        // Get input
        movement = new Vector3(InputManager.Instance.GetMovementInput().x, 0, InputManager.Instance.GetMovementInput().y);
        movement.Normalize();
        
        // Adjust movement relative to camera
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        
        Vector3 cameraRight = playerCamera.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();
        movement = cameraForward * movement.z + cameraRight * movement.x;

        // Move
        rb.linearVelocity = movement * speed + new Vector3(0, rb.linearVelocity.y, 0);

        //Rotate
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            model.transform.rotation = Quaternion.RotateTowards(model.transform.rotation, toRotation, 720 * Time.deltaTime);
        }

        // Animate
        animations.PlayRunAnimation(rb.linearVelocity.magnitude);
    }
}
