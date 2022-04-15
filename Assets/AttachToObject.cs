using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    public GameObject objectToAttachTo;

    //Start is called before the first frame update
    void Start()
    {
        this.transform.parent = objectToAttachTo.transform;
    }//Parent the object without unpacking the prefab. :) This way the eye lights move with the head for the Werewolf Chibi Character model..


}