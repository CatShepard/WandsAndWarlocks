using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<ScriptableCard> AllCards;
    List<ScriptableCard> usedDeck;
    List<ScriptableCard> deck;

    public void CreateBasicDeck()
    {
        deck = new List<ScriptableCard>();
        usedDeck = new List<ScriptableCard>();
        if (AllCards.Count > 0)
            deck.AddRange(AllCards);
        Debug.Log("cards: " + AllCards.Count + " deck: " + deck.Count);
    }

    public ScriptableCard DrawCard()
    {
        if (deck.Count + usedDeck.Count == 0)
            return null;

        if (deck.Count == 0)
        {
            deck.AddRange(usedDeck);
            usedDeck.Clear();
        }

        ScriptableCard card = deck[0];
        deck.RemoveAt(0);
        usedDeck.Add(card);

        return card;
    }

    // todo: Add a save and load deck
}
