using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public NPCScriptableObject npcData;
    private Image box;
    private Image checkMark;
    private float backgroundTransparency = .6f;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Image>();
        Color boxColor = new Color(npcData.dialogueBoxColor.r, npcData.dialogueBoxColor.g, npcData.dialogueBoxColor.b);
        boxColor.a = backgroundTransparency;
        box.color = boxColor;

        checkMark = this.transform.GetChild(0).GetComponent<Image>();
        //Consider changing: This relies on the checkbox always being in one spot..
        checkMark.color = npcData.textColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(npcData.talkedTo == true)
        {
            checkMark.enabled = true;
        }
    }
}