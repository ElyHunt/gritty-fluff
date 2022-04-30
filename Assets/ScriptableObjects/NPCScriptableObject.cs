using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New NPC", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public new string name;//new lets you use variable name "name". EOH

    public string[] lines;//Dialogue is stored in an array. EOH
    
    public Color dialogueBoxColor = Color.white;//Controls the color of the dialogue box as well as the "visor" of the capsule.
    public Color textColor = Color.black;//Controls the text color and the capsule color.

    public bool talkedTo = false;
    //In DisplayNPC.cs, this flag is changed once an NPC has been talked to.
    //This allows the checkbox to be checked in the UI. :)


    //Note: Scriptable Objects are like containers for data.
    //They help a lot with scalability and modularity and 
    //reduce the number of prefabs you have to have in a project. -EOH
}

