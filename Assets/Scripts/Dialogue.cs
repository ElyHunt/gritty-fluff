using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour//This script is the interface for the canvas with NPC for speaking.
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool displayingText;
    private float chatBackgroundTransparency = .6f;
    

    // Start is called before the first frame update
    void Start()
    {
        //textComponent.text = string.Empty;//Start the dialogue box out empty.
        displayingText = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        

        if(displayingText && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
            if(textComponent.text == lines[index])//If the text is finished loading
            { 
                NextLine();
            }
            else 
            {
                StopAllCoroutines();
                textComponent.text = lines[index];//Instantly loads the text if the user preses space.
            }
    }

    //Starts the speaking process.
    void StartDialogue()
    {

        index = 0;
        ToggleDisplayText();
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());

    }
    void NextLine()//gets next line and starts a coroutine to type it out
        //if at end of list, closes text box.
    {
        if(index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            ToggleDisplayText();
        }    
    }

    IEnumerator TypeLine()//Prints text one character at a time.
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);//speed characters display
        }
    }

    public void SpeakLines(string[] characterLines, Color backgroundColor, Color textColor)
    {
        if (displayingText)//If you talk to another NPC, they "interrupt" the other. :)
        {
            StopAllCoroutines();
            ToggleDisplayText();
        }

            backgroundColor.a = chatBackgroundTransparency;//lowers the alpha so chatbox is transparent.

            lines = characterLines;
            Image chatBackground = gameObject.GetComponent<Image>();
            chatBackground.color = backgroundColor;
            textComponent.color = textColor;
            StartDialogue();//This will allow characters with access to this script to speak their lines.
        
    }

    void ToggleDisplayText()//This is to turn on and off the dialogue box at the bottom of the screen HUD. (In canvas. :) )
    {
        displayingText = !displayingText;
        gameObject.GetComponent<Image>().enabled = displayingText;//hides the black box
        textComponent.enabled = displayingText;
    }


    public bool isDisplaying()
    {
        return displayingText;//accessor :)
    }

}
//Script adapted from:
//https://www.youtube.com/watch?v=8oTYabhj248
//~EOH