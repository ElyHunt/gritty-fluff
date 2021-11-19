using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNPC : MonoBehaviour
{
    public NPCScriptableObject npcData;
    public GameObject dialogueBox;
    public GameObject capsule;
    public GameObject visor;


    // Start is called before the first frame update
    void Start() { 
        capsule.GetComponent<MeshRenderer>().material.color = npcData.textColor;
        visor.GetComponent<MeshRenderer>().material.color = npcData.dialogueBoxColor;
        //Colors selected in npcData translate to the color of the character as well!
        //Potentially this will be replaced by a display Model to render.


    }

    public void speak()
    {
        dialogueBox.GetComponent<Dialogue>().SpeakLines(npcData.lines, npcData.dialogueBoxColor, npcData.textColor);
        //Load lines into dialogue box and display them.
        
    }


    public void checkCollision(Collider collision)
    { 
        //Debug.Log(collision.gameObject.transform.parent.name + " has been bumped. ");
        if (collision.gameObject.tag == "Player")
        {
            gameObject.transform.LookAt(collision.gameObject.transform.parent);
            //Remember! Collision is reported on the capsule's collider--but this script is on the
            //parent of the NPC capsule. The capsule forwards the collision here.
            speak();
        }
    }





}
