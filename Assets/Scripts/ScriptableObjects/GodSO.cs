using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GodsList", menuName = "GodsList", order = 51)]
public class GodSO : ScriptableObject
{
    [SerializeField]
    public God[] gods;
}
