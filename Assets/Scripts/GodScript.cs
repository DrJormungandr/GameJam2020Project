﻿using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodScript : MonoBehaviour
{
    bool clickActive = false;
    public God stats = new God();
    int dominanceVar;
    public GameObject dominanceBar;
    private GameObject canvas;
    private GameObject MainScript;
    private Slider slider;
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
        dbar.transform.position = new Vector2(RectTransformUtility.WorldToScreenPoint(Camera.main, (collider.transform.position)).x, 450);

    }

    // Update is called once per frame
    void Update()
    {
        if (dominanceVar != stats.Dominance)
        {
            slider.value = stats.Dominance;
            dominanceVar = stats.Dominance;
        }
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
