using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New DialogueList", menuName = "DialogueList", order = 51)]
    public class DialoguesList : ScriptableObject
    {
        [SerializeField]
       public List<DialogueModel> Dialogues;
    }
}
