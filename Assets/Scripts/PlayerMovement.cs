using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a basic movement script! We'll probably either add onto it or replace it. ~EOH

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody playerRigidBody;

    [Header("Player Movement Settings")]
    public float movementSpeed;
    public float rotateSpeed;
    public Camera mainCamera;
    private Animator werewolfAnimator;//animation controller!
    private bool moving = false;

    private void Start()
    {
        mainCamera = Camera.main;
        werewolfAnimator = this.GetComponentInChildren<Animator>();

    }

    void FixedUpdate() 
    {
        if (Input.anyKey)
        {
            MovePlayer(); //If a key is pressed, move the player. :)
            //NOTE: Animation triggered in MovePlayer. Refactor code for clarity!

        }
        else if(moving)//if no input and moving, turn walk animation off.
        {
            werewolfAnimator.SetBool("KeyPressed", false);
            moving = false;
        }
        //optimized with a bool gate, "moving"
    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput == 0 && verticalInput == 0) return;
        //Horizontal and Vertical Axes represent WASD. This can be changed in Unity preferences?
        //Might have to edit the line in FixedUpdate to reflect other input types, however
        werewolfAnimator.SetBool("KeyPressed", true);
        moving = true;//Start walk animation


        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        Vector3 movementDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
        //Calculates the movement direction based on the camera's rotation.
        //In the camera's script, it is set to look at the player at all times.

        movementDirection.Normalize();
        movementDirection.y = 0;

        transform.Translate(movementDirection * movementSpeed, Space.World);
        //Actual Movement of player. Speed can be set in editor.
        
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);//Turns from Euler to Quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed);
        //Uses Quaternions to do partial rotations each frame. rotateSpeed can be set in editor.
        //AKA Controls which direction the player is facing


        //EOH: Adapted from: https://www.youtube.com/watch?v=BJzYGsMcy8Q&t=256s & https://forum.unity.com/threads/moving-character-relative-to-camera.383086/


    }

}

/*
 Notes about Player:
Freeze rotation enabled so that Capsule won't fall over when it hits objects.
 */