using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNPC : MonoBehaviour
{
    public NPCScriptableObject npcData;
    public GameObject dialogueBox;
    public GameObject capsule;
    public GameObject[] visor;

    private Material displayMaterial;

    private Animator werewolfAnimator;

    // Start is called before the first frame update
    void Start() { 
        //capsule.GetComponent<Renderer>().material.color = npcData.textColor;

        displayMaterial = new Material(capsule.GetComponent<Renderer>().material);
        displayMaterial.shader = Shader.Find("Standard (Specular setup)");
        displayMaterial.SetColor("_EmissionColor", npcData.textColor);
        displayMaterial.color = npcData.textColor;
        capsule.GetComponent<Renderer>().material = displayMaterial;
        //displayMaterial.CopyPropertiesFromMaterial(capsule.GetComponent<Renderer>().material);

        //To anyone else! The Unity editor automatically takes care of enabling this if you use the editor to look at the shader settings.
        //However, the Emission color will not apply unless you enable it using the following line of code. :) Took me a few hours to find!
        displayMaterial.EnableKeyword("_EMISSION");




        visor[0].GetComponent<Light>().color = npcData.dialogueBoxColor;
        visor[1].GetComponent<Light>().color = npcData.dialogueBoxColor;
        visor[2].GetComponent<Light>().color = npcData.dialogueBoxColor;
        visor[3].GetComponent<Light>().color = npcData.dialogueBoxColor;
        //Colors selected in npcData translate to the color of the character as well!
        //Potentially this will be replaced by a display Model to render.

        werewolfAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (Random.Range(1, 1000)==1) werewolfAnimator.SetTrigger("IdleBEngaged");
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
            gameObject.transform.LookAt(collision.gameObject.transform);
            //Remember! Collision is reported on the capsule's collider--but this script is on the
            //parent of the NPC capsule. The capsule forwards the collision here.

            werewolfAnimator.SetTrigger("IdleBEngaged");
            //Play Idle B when player talks to.

            speak();


        }
    }





}
