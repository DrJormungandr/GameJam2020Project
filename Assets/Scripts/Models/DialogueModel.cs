using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class DialogueModel
    {
        public string dialogueId;
        public bool tiedToEvent;
        public List<DialoguePhraseModel> sequence;
    }
}
