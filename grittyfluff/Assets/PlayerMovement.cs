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

    void FixedUpdate() //FixedUpdate is for Physics, right?
    {
        if (Input.anyKey) MovePlayer(); //If a key is pressed, move the player. :)
    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Horizontal and Vertical Axes represent WASD. This can be changed in Unity preferences?
        //Might have to edit the line in FixedUpdate to reflect other input types, however


        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed, Space.World);
        //Actual Movement of player. Speed can be set in editor.
        
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);//Turns from Euler to Quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed);
        //Uses Quaternions to do partial rotations each frame. rotateSpeed can be set in editor.
        //AKA Controls which direction the player is facing


        //EOH: Adapted from: https://www.youtube.com/watch?v=BJzYGsMcy8Q&t=256s
    }

}
