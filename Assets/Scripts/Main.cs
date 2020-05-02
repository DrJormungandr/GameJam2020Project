using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Enums;
using System;
using System.Linq;

public class Main : MonoBehaviour
{
    public GodSO godsList;
    public God[] gods;
    public EventsData eventsData;
    public GameObject Bubble;
    IEventService eventService;
    GameObject canvas;
    TextMeshProUGUI textmesh;
    public 

    // Start is called before the first frame update
    void Start()
    {
        gods = godsList.gods;
        this.eventService = new BasicEventService();
        this.canvas = GameObject.Find("Canvas");
        this.textmesh = canvas.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        StartCoroutine(this.Wait());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3);
        Debug.Log("EventStarted");
        this.StartEvent();

    }


    void StartEvent()
    {
        Event @event = this.eventService.GenerateEvent(this.eventsData, Ages.Age1);
        this.textmesh.text = @event.Description;
        foreach ( God god in gods) {
            Debug.Log(god.GodGO.transform.position);
            GameObject Bubble = Instantiate(this.Bubble, this.canvas.transform);
            
            Bubble.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, god.GodGO.transform.position) + new Vector2(0, 120);
            EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == god.Name);
            TextMeshProUGUI optionText = Bubble.transform.Find("OptionText").GetComponent<TextMeshProUGUI>();
            optionText.text = option.Description;
            Bubble.SetActive(true);
        }
        StopCoroutine(this.Wait());
    }

    void Clicked()
    {
        this.eventService.EventResult(eventsData.@event[0].Options[0], gods);
    }

}
