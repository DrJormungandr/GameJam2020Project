using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        text = canvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        switch (EndGame.Sender) {
            case "Jesus":
                senderJesus();
                break;
            case "Ganesh":
                senderGanesh();
                break;
            case "Cthulhu":
                senderCthulhu();
                break;
            case "Snek":
                senderSnek();
                break;
            case "Player":
                senderPlayer();
                break;
            default:
                Debug.LogError("WHO THE FUCK IS THAT?!?!?!?!?!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void senderJesus()
    {
        if (EndGame.won)
        {
            text.text = "Jesus won";
        }
        else
        {
            text.text = "Jesus died for your sins, dipshit";
        }
    }

    private void senderGanesh()
    {
        if (EndGame.won)
        {
            text.text = "Ganesh won";
        }
        else
        {
            text.text = "Elephant-Hippie died";
        }
    }
    private void senderCthulhu()
    {
        if (EndGame.won)
        {
            text.text = "Cthulhu won";
        }
        else
        {
            text.text = "Cthulhu fell asleep(and died)";
        }
    }

    private void senderSnek()
    {
        if (EndGame.won)
        {
            text.text = "Jormungandr won";
        }
        else
        {
            text.text = "Not being capable to handle this much stress, Jormungandr ate himself completely";
        }
    }

    private void senderPlayer()
    {
        if (EndGame.won)
        {
            text.text = "You won, congratulations";
        }
        else
        {
            text.text = "WTF?! This is not supposed to happen";
        }
    }
}
