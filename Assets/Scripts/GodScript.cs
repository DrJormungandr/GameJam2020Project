using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GodScript : MonoBehaviour
{
    bool clickActive = false;
    public God stats = new God();
    int dominanceVar;
    public GameObject dominanceBar;
    public int maxDominance = 10;
    private GameObject canvas;
    private GameObject MainScript;
    private Slider slider;

    public Animator animator; //for animation purposes A.

    // Start is called before the first frame update
    void Start()
    {
        MainScript = GameObject.Find("ScriptManager");
        dominanceVar = stats.Dominance;
        this.canvas = GameObject.Find("Canvas");
        GameObject dbar = Instantiate(this.dominanceBar, this.canvas.transform);
        var collider = GetComponent<CapsuleCollider>();
        slider = dbar.GetComponent<Slider>();
        slider.value = stats.Dominance;
        dbar.transform.position = new Vector2(collider.transform.position.x, 9);

    }

    // Update is called once per frame
    void Update()
    {
        if (dominanceVar != stats.Dominance)
        {
            slider.value = stats.Dominance;
            dominanceVar = stats.Dominance;
        }
        if (stats.Dominance > maxDominance)
        {
            EndGame.Sender = stats.Name;
            EndGame.won = true;
            SceneManager.LoadScene("EndGame");
        }
        if (stats.Dominance < 1)
        {
            EndGame.Sender = stats.Name;
            EndGame.won = false;
            SceneManager.LoadScene("EndGame");
        }
    }

    private void OnMouseDown()
    {
        if (EventFired.godsClickable == true)
        {
            FindObjectOfType<AudioSystem>().Play("GodClick");
            animator.SetTrigger("talk");
            MainScript.SendMessage("GodClicked", stats.Name);
            EventFired.godsClickable = false;
        }
    }

    private void OnEventFired()
    {
        clickActive = true;
    }
}
