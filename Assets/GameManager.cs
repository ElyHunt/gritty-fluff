using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Check if the game has been "won"! :)
public class GameManager : MonoBehaviour
{
    public GameObject gameWinScreen;
    public GameObject inventory;//UI Checkboxes
    private List<Image> checkBoxes;
    bool gameWon = false;

    private void Start()
    {
        checkBoxes = new List<Image>();
        Image[] inventoryElements = inventory.transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < inventoryElements.Length; i++) 
            if (inventoryElements[i].CompareTag("CheckBoxes")) 
                checkBoxes.Add(inventoryElements[i]);
    }

    // Update is called once per frame
    void Update()
    {
        gameWon = checkIfGameOver();
    }


    private bool checkIfGameOver()
    {
        for (int i = 0; i < checkBoxes.Count; i++)
        {
            if (checkBoxes[i].enabled == false) return false;
            //if all checkBoxes are checked, you win!
        }
        gameWinScreen.SetActive(true);
        return true;
    }

}
