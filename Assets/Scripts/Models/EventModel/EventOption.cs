using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class EventOption
    {
        public string Description;
        public string GodName;
        public EventGodEffect[] GodsEffect;
        public EventWorldEffect WorldEffect;
    }
}
