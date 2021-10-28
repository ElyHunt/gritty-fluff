using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;//Start the dialogue box out empty.
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            if(textComponent.text == lines[index])//If the text is finished loading
            { 
                NextLine();
            }
            else 
            { StopAllCoroutines(); }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()//Prints text one character at a time.
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);//speed characters display
        }

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
            gameObject.SetActive(false);
        }    
    }    
}
//Script adapted from:
//https://www.youtube.com/watch?v=8oTYabhj248
//~EOH