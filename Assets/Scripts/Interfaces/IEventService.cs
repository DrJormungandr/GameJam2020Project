using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    interface IEventService
    {
        Event GenerateEvent();
        void StartEvent(Event @event);
        void EventResult(EventOption option, God[] gods);
    }
}
