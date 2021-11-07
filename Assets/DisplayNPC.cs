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

         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void speak()
    {
        dialogueBox.GetComponent<Dialogue>().SpeakLines(npcData.lines, npcData.dialogueBoxColor, npcData.textColor);//Load lines and make NPC Speak.
    }


    public void checkCollision(Collider collision)
    { 
        Debug.Log(collision.gameObject.transform.parent.name + " has been bumped. ");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(npcData.name + " is NOW SPEAKING!");
            speak();
        }
    }





}
