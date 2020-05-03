using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IDialogueService
    {
        DialoguePhraseModel[] getDialogue(string dialogueId);
        List<string> fetchIDs();
    }
}
