using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    God[] gods;
    public EventsData eventsData;
    IEventService eventService;
    GameObject canvas;
    TextMeshProUGUI textmesh;
    public 

    // Start is called before the first frame update
    void Start()
    {
        this.eventService = new BasicEventService();
        this.canvas = GameObject.Find("Canvas");
        Debug.Log(this.canvas);
        this.textmesh = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        Debug.Log(this.textmesh);
        this.Wait();


    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning("I'M DEAD");
        textmesh.text = "Я мудак";
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(10);

    }

    void Clicked()
    {
        this.eventService.EventResult(eventsData.@event[0].Options[0], gods);
        

    }

}
