using UnityEngine;
using UnityEngine.EventSystems;

public class EventDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 camera_offset;
    Vector3 position_offset;

    void Start()
    {
        // Offset the z-value of the camera
        camera_offset = Camera.main.ScreenToWorldPoint(Vector3.zero);
        camera_offset.x = 0;
        camera_offset.y = 0;
        camera_offset.z = -camera_offset.z;
        //Debug.Log("Camera offset: " + camera_offset);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //position_offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        position_offset = transform.position - (Vector3)eventData.position;
        //position_offset.z = 0;
        //Debug.Log("Position offset: " + position_offset);
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        // Store object's z-value (since position is Vector2)
        float z = transform.position.z;

        //Vector3 newPos = Camera.main.ScreenToWorldPoint(eventData.position) + camera_offset + position_offset;
        //Vector3 newPos = Camera.main.ScreenToWorldPoint(eventData.position) + position_offset;
        Vector3 newPos = (Vector3)eventData.position + position_offset;
        newPos.z = z;

        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
