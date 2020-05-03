using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    TextMeshProUGUI text;
    public Sprite[] sprites;

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
            gameObject.GetComponent<Image>().sprite = sprites[0];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprites[1];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
    }

    private void senderGanesh()
    {
        if (EndGame.won)
        {
            gameObject.GetComponent<Image>().sprite = sprites[2];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprites[3];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
    }
    private void senderCthulhu()
    {
        if (EndGame.won)
        {
            gameObject.GetComponent<Image>().sprite = sprites[4];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprites[5];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
    }

    private void senderSnek()
    {
        if (EndGame.won)
        {
            gameObject.GetComponent<Image>().sprite = sprites[6];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprites[7];
            FindObjectOfType<AudioSystem>().Play("Lose");
        }
    }

    private void senderPlayer()
    {
        if (EndGame.won)
        {
            gameObject.GetComponent<Image>().sprite = sprites[8];
            FindObjectOfType<AudioSystem>().Play("Win");
        }
        else
        {
            Debug.Log("lol u broke da game");
        }
    }
}
