using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodScript : MonoBehaviour
{
    bool clickActive = false;
    public God stats = new God();
    private GameObject MainScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MainScript = GameObject.Find("ScriptManager");
    }

    private void OnMouseDown()
    {
        if (clickActive)
        {
            MainScript.SendMessage("GodClicked", stats.Name);
            clickActive = false;

        }
    }

    private void OnEventFired()
    {
        clickActive = true;
    }
}
