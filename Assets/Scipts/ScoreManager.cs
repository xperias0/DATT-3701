using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int FinalScore = 0;

    public int maxSaltScore = 30;

    public int saltScore = 0;

    int maxFinalScore = 100;
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetButtonDown("Finish")) {
            Debug.Log("Done! ");
            FInalCodition();
        }
    }
    public void addScore(int addNum ) {
       
             FinalScore+= addNum;
        if (FinalScore > maxFinalScore)
        {
            FinalScore = maxFinalScore;
        }
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: "+FinalScore;
    }

    public void addSalt() {
        if (saltScore<maxSaltScore) {
            saltScore++;
            FinalScore+=1;
            GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: " + FinalScore;

        }
    }

    public void FInalCodition() {
        if (FinalScore > 50)
        {
            GameObject.Find("Condition").GetComponent<TextMeshProUGUI>().text = "Nice Job!";
        }
        else {

            GameObject.Find("Condition").GetComponent<TextMeshProUGUI>().text = "You made a bad dish :(";

        }
    }

}
