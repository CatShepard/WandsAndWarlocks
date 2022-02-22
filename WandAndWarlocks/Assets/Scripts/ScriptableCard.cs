using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Data")]
public class ScriptableCard : ScriptableObject
{
    [Header("Card graphics")]
    public Sprite cardImage;
}
