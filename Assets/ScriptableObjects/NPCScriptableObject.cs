using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New NPC", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public new string name;//new lets you use variable name "name".

    public string[] lines;//These are will be replaced by a randomly generated system or dialogue tree or something?
    //For now, just make it a single "conversation".
    public Color dialogueBoxColor;
    public Color textColor;

}
