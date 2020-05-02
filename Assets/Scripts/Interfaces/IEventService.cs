using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    interface IEventService
    {
        Event GenerateEvent( Event[] eventsList, Ages Age);
        void StartEvent(Event @event);
        void EventResult(EventOption option, Dictionary<string, God> godStats);
    }
}
