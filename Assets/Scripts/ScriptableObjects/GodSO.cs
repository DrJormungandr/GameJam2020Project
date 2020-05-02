using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GodsSettings", menuName = "GodsSettings", order = 51)]
public class GodSettings : ScriptableObject
{
    [SerializeField]
    public God god;
}
