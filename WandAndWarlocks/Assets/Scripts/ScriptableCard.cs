using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Definitions;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Data")]
public class ScriptableCard : ScriptableObject
{
    [Header("Card graphics")]
    public Sprite cardImage;

    [Header("Card Info")]
    public string cardName;
    public string flavorText;

    [Header("Card Stats")]
    public int hp;
    public int dps;
    public Vector2 footprint;
    public CardType type;
    public CardRarity rarity;
}
