using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Definitions;

public class CardUIBehavior : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    ScriptableCard card;
    Vector3 originalPosition;

    public Image imageCardPic;
    public TextMeshProUGUI textCardName;
    public TextMeshProUGUI textFlavorText;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textDPS;
    public Image type;
    // Should this be 
    public Image rarity;

    public void SetCard(ScriptableCard newCard)
    {
        card = newCard;
        imageCardPic.sprite = newCard.cardImage;
        textCardName.text = newCard.cardName;
        textFlavorText.text = newCard.flavorText.ToString();
        textHP.text = newCard.hp.ToString();
        textDPS.text = newCard.dps.ToString();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag before: " + transform.position);
        transform.Translate(eventData.delta);
        Debug.Log("Drag after: " + transform.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = originalPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = transform.position;
    }
}
