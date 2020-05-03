using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Event
{
    public string Description;
    public Ages Age;
    public EventOption[] Options;
    public bool tiedtoDialogue;
    public string tiedDialogueId;
}
