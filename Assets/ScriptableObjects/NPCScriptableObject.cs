using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCScriptableObject", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public string name;

    public string[] lines;//These are will be replaced by a randomly generated system or dialogue tree or something?
    public Image dialogueBox;
    public Color dialogueBoxColor;
    public Color textColor;


    public void speak()
    {
        dialogueBox.GetComponent<Dialogue>().SpeakLines(lines, dialogueBoxColor, textColor);//Load lines and make NPC Speak.
    }
    



}
