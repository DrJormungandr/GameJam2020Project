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
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
  //  public GodSO godsList;
    Dictionary<string, God> godObjectStats =  new Dictionary<string, God>();
    List<GameObject> bubbles = new List<GameObject>();
    [SerializeField]
    public Ages[] ages;
    public int eventsPerAge;
    private int agesCounter = 0;
    private int eventsCounter = 0;
    public EventsData eventsData;
    List<Event> eventList;
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
            God godStats;
            try
            {
                godStats = god.GetComponent<GodScript>().stats;
            } catch
            {
                godStats = new God();
            }
            godObjectStats.Add(godStats.Name, god.GetComponent<GodScript>().stats);
        }
        eventList = ((Event[])eventsData.@event.Clone()).ToList<Event>();
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
        Debug.Log($"event {eventsCounter}");

        checkEventsPerAge();
        if (agesCounter <= ages.Length - 1)
        {
            Debug.Log($"age {agesCounter}");
        }
        else
        {
            EndGame.Sender = "Player";
            EndGame.won = true;
            SceneManager.LoadScene("EndGame");
            return;
        }
        @event = eventService.GenerateEvent(this.eventList.ToArray(), ages[agesCounter]);
        eventsCounter++;
        this.textmesh.text = @event.Description;
        foreach ( GameObject god in currentGods) {
            GameObject bubble = Instantiate(this.Bubble, this.canvas.transform);
            bubbles.Add(bubble);
            var collider = god.GetComponent<CapsuleCollider>();
            bubble.transform.position = new Vector2(collider.transform.position.x, 7);
            string godsName = god.GetComponent<GodScript>().stats.Name;
            EventOption option;
            try
            {
                option = @event.Options.First(ev => ev.GodName == godsName);
            } catch
            {
                option = new EventOption();
                option.GodName = godsName;
                option.Description = $"ERR: {@event.Description}";
                
            }
            TextMeshProUGUI optionText = bubble.transform.Find("OptionText").GetComponent<TextMeshProUGUI>();
            optionText.text = option.Description;
            bubble.SetActive(true);
        }
        StopCoroutine(this.Wait());
        EventFired.godsClickable = true;
        foreach( GameObject go in currentGods) {
            go.SendMessage("OnEventFired");
        }
      //  SendMessage("onEventFired");
    }

    void GodClicked(string godName)
    {
        EventOption option = @event.Options.FirstOrDefault(ev => ev.GodName == godName);
        try
        {
            eventService.EventResult(option, godObjectStats);
        } catch (KeyNotFoundException e)
        {
            Debug.LogError($"ERROR in: {option.Description}; WrongGodAffectedNames: {e}");
        }
            StartCoroutine(Wait());
            foreach (GameObject bubble in bubbles)
            {
                Destroy(bubble);
            }
            this.eventList.Remove(@event);
    }

    private void checkEventsPerAge()
    {
        if (eventsCounter >= eventsPerAge)
        {
            eventsCounter = 0;
            agesCounter++;
        }
    }
}
