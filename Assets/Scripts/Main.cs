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
  //  public GodSO godsList;
    Dictionary<string, God> godObjectStats =  new Dictionary<string, God>();
    List<GameObject> bubbles = new List<GameObject>();
    public EventsData eventsData;
    Event[] eventList;
    public GameObject Bubble;
    IEventService eventService;
    GameObject canvas;
    TextMeshProUGUI textmesh;
    private Event @event;
    private List<GameObject> currentGods = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(Transform god in GameObject.Find("Gods").transform)
        {
            currentGods.Add(god.gameObject);
            God godStats = god.GetComponent<GodScript>().stats;
            godObjectStats.Add(godStats.Name, god.GetComponent<GodScript>().stats);
        }



        eventList = (Event[])eventsData.@event.Clone();
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
        @event = eventService.GenerateEvent(this.eventList, Ages.Age1);
        this.textmesh.text = @event.Description;
        foreach ( GameObject god in currentGods) {
            GameObject bubble = Instantiate(this.Bubble, this.canvas.transform);
            bubbles.Add(bubble);
            var collider = god.GetComponent<CapsuleCollider>();
            bubble.transform.position = new Vector2(RectTransformUtility.WorldToScreenPoint(Camera.main, (collider.transform.position)).x, 400);
            string godsName = god.GetComponent<GodScript>().stats.Name;
            EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == godsName);
            TextMeshProUGUI optionText = bubble.transform.Find("OptionText").GetComponent<TextMeshProUGUI>();
            optionText.text = option.Description;
            bubble.SetActive(true);
        }
        StopCoroutine(this.Wait());
        foreach( GameObject go in currentGods) {
            go.SendMessage("OnEventFired");
        }
      //  SendMessage("onEventFired");
    }

    void GodClicked(string godName)
    {
        EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == godName);
        eventService.EventResult(option, godObjectStats);
        StartCoroutine(Wait());
         foreach (GameObject bubble in bubbles)
        {
            Destroy(bubble);
        }
        
    }

}
