using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodScript : MonoBehaviour
{
    bool clickActive= false;
    public string godName;
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
            Debug.Log("Clicked");
            MainScript.SendMessage("GodClicked", godName);
            clickActive = false;

        }
    }

    private void OnEventFired()
    {
        Debug.Log("Event Fired");
        clickActive = true;
    }
}
