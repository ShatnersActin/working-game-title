using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Samples;
using UnityEngine.Networking;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ClientNetworkTransform))]

public class PlayerController : NetworkBehaviour
{
    public float speed = 6;
    public float jumpSpeed;
    public float turnSmoothTime = 0.1f;
    public float sprintSpeed;

    private float turnSmoothVelocity;
    private float gravity;
    private bool isSprinting = false;

    public CharacterController controller;
    public Transform cam;

    private float movementX;
    private float movementY;

    private void Awake()
    {

    }
    void Start()
    {
        if(IsClient && IsOwner)
        {
            GameObject cameraFollow = GameObject.Find("ThirdPersonCamera");
            cameraFollow.GetComponent<FollowPlayer>().TrackPlayer(transform);
        }
    }

    void FixedUpdate()
    {
        if (IsClient && IsOwner)
        {
            
            GameObject playerCamera = GameObject.Find("Camera");
            cam = playerCamera.transform;
            gravity += Physics.gravity.y * Time.deltaTime;
            Vector3 movement = new Vector3(movementX, 0.0f, movementY).normalized;

            if (movement.magnitude >= 0.1f && isSprinting == false)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                Vector3 motion = moveDirection.normalized * speed;
                motion.y = gravity;
                controller.Move(motion * Time.deltaTime);
            }

            if (movement.magnitude >= 0.1f && isSprinting == true)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                Vector3 motion = moveDirection.normalized * sprintSpeed;
                motion.y = gravity;
                controller.Move(motion * Time.deltaTime);
            }

            if (controller.isGrounded)
            {
                gravity = 0f;
            }

            if (movement.magnitude <= 0.1f)
            {
                isSprinting = false;
            }
        }
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump()
    {
        if (controller.isGrounded)
        {
            gravity = jumpSpeed;
            Debug.Log("Jumping!");
        }
        
    }

    void OnSprint()
    {
        if (controller.isGrounded)
        {
            Debug.Log("Sprint On");
            isSprinting = true;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        float radius = gameObject.GetComponent<TargetManager>().targetRange;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
