using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
   public class BasicDialogueService : IDialogueService
    {
        private readonly List<DialogueModel> dialogList;
        public BasicDialogueService(List<DialogueModel> dialogues)
        {
            dialogList = dialogues;
        }

        public DialoguePhraseModel[] getDialogue(string dialogueId)
        {

            DialogueModel dmodel = dialogList.FirstOrDefault(dlg => dlg.dialogueId == dialogueId);
            DialoguePhraseModel[] dialogueSequence = dmodel.sequence.ToArray();
            return dialogueSequence;
        }

        public List<string> fetchIDs()
        {
            List<string> ids = new List<string>();
            foreach (DialogueModel dial in dialogList)
            {
                if (!dial.tiedToEvent);
                ids.Add(dial.dialogueId);
            }
            return ids;
        }
    }
}
