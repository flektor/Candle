using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    EventTrigger _eventTrigger;
    TextMeshProUGUI text;
    Color _initColor;
    
    void Start()
    {
        _eventTrigger = gameObject.AddComponent<EventTrigger>();
         
        EventTrigger.Entry pointerEnterEntry = new ();
        pointerEnterEntry.eventID = EventTriggerType.PointerEnter;
        pointerEnterEntry.callback.AddListener((data)=>OnPointerEnter());

        EventTrigger.Entry pointerExitEntry = new ();
        pointerExitEntry.eventID = EventTriggerType.PointerExit;
        pointerExitEntry.callback.AddListener((data) => OnPointerExit());
         
        EventTrigger.Entry pointerClickEntry = new();
        pointerClickEntry.eventID = EventTriggerType.PointerClick;
        pointerClickEntry.callback.AddListener((data) => OnPointerExit());

        _eventTrigger.triggers.Add(pointerEnterEntry);
        _eventTrigger.triggers.Add(pointerClickEntry);
        _eventTrigger.triggers.Add(pointerExitEntry); 
         
        text = GetComponentInChildren<TextMeshProUGUI>();
        _initColor = text.color;
    }

    public void OnPointerEnter()
    {
        text.color = Color.white;
    }

    public void OnPointerExit()
    {
        text.color = _initColor;
    }
}
