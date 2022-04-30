using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameWinScreen;
    public GameObject[] checkBoxes;//UI Checkboxes
    bool gameWon = false;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < checkBoxes.Length; i++)
        {
            if (checkBoxes[i].GetComponent<Image>().enabled == true) gameWon = true;
            else break;//if all checkBoxes are checked, you win! Otherwise, break!
        }
    }
}
