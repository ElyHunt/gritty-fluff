using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject defaultFocus;
    //Typically Player, controls what camera looks at by default. Doesn't change. Set in Editor.
    private GameObject currentFocus;
    //Typically Player, controls what camera looks at currently.
    private GameObject holderFocus;
    //Stores old focus for swapping back and forth.

    public float rotationSensitivity = 1f;

    private float lastRotateY = 0;
    private float lastRotateX = 0;

    //Initializes focus to default.
    private void Start()
    {
        currentFocus = defaultFocus;
        this.transform.LookAt(currentFocus.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
        calculateCameraRotation();
    }


    //Performs the calculations to look at the player and to allow the mouse to pan around the scene.
    private void calculateCameraRotation()
    { 

        this.transform.Rotate(new Vector3(0, 1, 0), lastRotateX);
        lastRotateX = (Input.GetAxis("Mouse X") * rotationSensitivity) + lastRotateX;
        if (lastRotateX >= 45) lastRotateX = 45;
        else if (lastRotateX <= -45) lastRotateX = -45;//Calculates the left and right panning of camera

        this.transform.Rotate(new Vector3(1, 0, 0), lastRotateY);
        lastRotateY = (-Input.GetAxis("Mouse Y") * rotationSensitivity) + lastRotateY;
        if (lastRotateY >= 90) lastRotateY = 90;
        else if (lastRotateY <= -90) lastRotateY = -90;//Calculates the up and down panning of camera



        this.transform.LookAt(new Vector3(currentFocus.transform.position.x, currentFocus.transform.position.y, currentFocus.transform.position.z));//Looks at the player as it moves

        this.transform.Rotate(new Vector3(0, 1, 0), lastRotateX);
        this.transform.Rotate(new Vector3(1, 0, 0), lastRotateY);//Re-rotates after the player moves to preserve panning.

    }//There may be a better way to do this--Refactor needed? -EOH




    //Looks at the default gameObject.
    public void lookAtDefault()
    {
        holderFocus = defaultFocus;
        swapFocus();
    }
    //Tells the camera to look at a new game object.
    public void lookAtNew(GameObject focus)
    {
        holderFocus = focus;
        swapFocus();
    }

    //Swaps back to what was being looked at previously. Useful for back-and-forth conversation.
    public void swapFocus()
    {
        if(holderFocus != null)
        {
            GameObject temp = currentFocus;
            currentFocus = holderFocus;
            holderFocus = temp;
        }
    }
}
