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
    public EventsData eventsDataSO;
    public Event[] eventList;
    public GameObject Bubble;
    IEventService eventService;
    GameObject canvas;
    TextMeshProUGUI textmesh;
    private Event @event;
    private List<GameObject> currentGods = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach( Transform god in GameObject.Find("Gods").transform)
        {
            currentGods.Add(god.gameObject);
        }
        eventList = eventsDataSO.@event;
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
        StartEvent();

    }


    void StartEvent()
    {
        @event = eventService.GenerateEvent(this.eventsData, Ages.Age1);
        this.textmesh.text = @event.Description;
        foreach ( God god in gods) {
            GameObject Bubble = Instantiate(this.Bubble, this.canvas.transform);
            var collider = god.GodGO.GetComponent<CapsuleCollider>();
            //Bubble.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, (collider.center)) + new Vector2(collider.center.x, 249);
            Bubble.transform.position = new Vector2(RectTransformUtility.WorldToScreenPoint(Camera.main, (collider.transform.position)).x, 400);
            EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == god.Name);
            TextMeshProUGUI optionText = Bubble.transform.Find("OptionText").GetComponent<TextMeshProUGUI>();
            optionText.text = option.Description;
            Bubble.SetActive(true);
        }
        StopCoroutine(this.Wait());
        foreach( GameObject go in currentGods) {
            Debug.Log(go.name);
            go.SendMessage("OnEventFired");
        }
      //  SendMessage("onEventFired");
    }

    void GodClicked(string godName)
    {
        EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == godName);
        eventService.EventResult(option, gods);
        StartCoroutine(Wait());
        foreach (God god in gods)
        {
            Debug.Log(god.Name);
            Debug.Log(god.Dominance);
        }
        
    }

}
