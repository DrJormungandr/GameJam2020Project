using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EventsData", menuName = "EventsData", order = 51)]
public class EventsData : ScriptableObject
{
    [SerializeField]
    public Event[] @event;
}
