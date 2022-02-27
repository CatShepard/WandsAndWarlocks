using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    DeckManager deckManager;
    List<CardUIBehavior> hand;
    GameObject panelHand;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (deckManager == null)
        {
            Debug.LogError("Couldn't find the DeckManager in CardGameManager");
            return;
        }
        panelHand = GameObject.Find("Panel_Hand");


        deckManager.CreateBasicDeck();
        hand = new List<CardUIBehavior>();
        DrawHand();
    }

    // Draw Hand ?
    void DrawHand()
    {
        // Just drawing a hard coded 5 cards for now
        for (int i = 0; i < 5; i++)
        {
            ScriptableCard draw = deckManager.DrawCard();
            GameObject newCard = Instantiate<GameObject>(cardPrefab, panelHand.transform);
            CardUIBehavior cardBehavior = newCard.GetComponent<CardUIBehavior>();
            cardBehavior.SetCard(draw);
            hand.Add(cardBehavior);
        }
    }
}