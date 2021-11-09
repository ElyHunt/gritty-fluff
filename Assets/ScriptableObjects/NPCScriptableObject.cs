using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New NPC", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public new string name;//new lets you use variable name "name".

    public string[] lines;//Dialogue is stored in an array.
    
    public Color dialogueBoxColor = Color.white;
    public Color textColor = Color.black;


}
