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
        public void EventResult(EventOption option, God[] gods)
        {
            List<EventGodEffect> godEffects = option.GodsEffect.ToList();
            foreach ( EventGodEffect godEffect in godEffects)
            {
                foreach( God god in gods)
                {
                    if (god.Name == godEffect.GodAffected)
                    {
                        god.Dominance += godEffect.DominanceChange;
                    }
                }
            }
        }

        public Event GenerateEvent()
        {
            Event @event = new Event();
       /*     List<EventOption> options = new List<EventOption>();
            @event.Description = "Ты пес";
            @event.Options = options.ToArray(); */
            return @event; 
        }

        public void StartEvent(Event @event)
        {

        }

        /*
        private EventOption generateEventOption(string optionDescription, string nameOfGod)
        {
            EventOption option = new EventOption();
            List<EventGodEffect> godsAndEffect = new List<EventGodEffect>(); ;

            godsAndEffect.Add(generateGodAndEffect("Jesus", 3));
            godsAndEffect.Add(generateGodAndEffect("Cthulu", -5));
            godsAndEffect.Add(generateGodAndEffect("Jormungandr", 5));

            EventWorldEffect worldEffect = new EventWorldEffect();
            option.Description = optionDescription;
            option.GodName = nameOfGod;
            option.GodsEffect = godsAndEffect.ToArray();
            option.WorldEffect = worldEffect;
            return option;
        }

        private EventGodEffect generateGodAndEffect(string godName, int dominanceChange)
        {
            EventGodEffect godEffect = new EventGodEffect();
            godEffect.GodAffected = godName;
            godEffect.DominanceChange = dominanceChange;

            return godEffect;
        } */
    } 
}
