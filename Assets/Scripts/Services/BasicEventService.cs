using Assets.Scripts.Enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{

    public class BasicEventService : IEventService
    {
        Canvas Canvas;
        public void EventResult(EventOption option, Dictionary<string, God> godStats)
        {
            List<string> errors = new List<string>();
            List<EventGodEffect> godEffects = option.GodsEffect.ToList();
            foreach (EventGodEffect godEffect in godEffects)
            {
                try
                {
                    godStats[godEffect.GodAffected].Dominance += godEffect.DominanceChange;
                } catch (KeyNotFoundException e)
                {
                    errors.Add(godEffect.GodAffected);
                }
            }
            if (errors.ToArray().Length > 0)
            {
                throw new KeyNotFoundException(String.Join<string>(" ,", errors));
            }
        }

        public Event GenerateEvent(Event[] eventsList, Ages Age)
        {
            List<Event> ageEvents = new List<Event>();
            foreach (Event @event in eventsList)
            {
                if (@event.Age == Age)
                {
                    ageEvents.Add(@event);
                }
            }
            int eventNum = UnityEngine.Random.Range(0, (ageEvents.ToArray().Length-1));
            Event outEvent = ageEvents[eventNum];
            return outEvent;
        }

        public void StartEvent(Event @event)
        {

        }
    } 
}

