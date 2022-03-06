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

    //Initializes focus to default.
    private void Start()
    {
        currentFocus = defaultFocus;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(currentFocus.transform.localPosition);
    } //look at currentFocus continually

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
