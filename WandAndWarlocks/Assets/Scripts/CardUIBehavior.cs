using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUIBehavior : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    ScriptableCard card;
    Vector3 originalPosition;

    public void SetCard(ScriptableCard newCard)
    {
        card = newCard;
        GetComponent<Image>().sprite = newCard.cardImage;
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
