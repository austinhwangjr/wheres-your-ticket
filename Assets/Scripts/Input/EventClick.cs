using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    private void Awake()
    {

    }

    // NOTE FOR FUTURE SELF
    // https://docs.unity3d.com/2018.3/Documentation/ScriptReference/EventSystems.PointerEventData.html
    // PointerEventData eventData is payload for pointer events (mouse/touch)
    // eventData.button = Left/Right/Middle for mouse
    // eventData.position for position of mouse

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //once left mouse button is pressed on object
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //once left mouse button is released on object
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //once mouse stops colliding with object
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //once mouse collides with object
    }

    public void OnMouseDown()
    {
        
    }
}
