/**
 * WireDragHandler.cs
 * 
 * This script contains the logic for the wire-matching game.
 * Clicking on a wire will drag it.
 * 
 * @author Austin Hwang
 * @date 7 October 2025
 */
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WireDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 start_point;
    private Vector3 start_position;
    private Transform snap_target;

    [SerializeField]
    private CanvasRenderer wire_end;
    [SerializeField]
    private GameObject light_on;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_point = transform.parent.position;
        start_position = transform.position;
        snap_target = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Reset the snap target
        snap_target = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update moving wire's position on pointer drag
        // Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        // newPosition.z = transform.position.z;
        // transform.position = newPosition;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition += eventData.delta;

        // Check for nearby connection points for snapping
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        // foreach (Collider2D collider in colliders)
        // {
        //     // Check if not self
        //     if (collider.gameObject != gameObject)
        //     {
        //         // Update wire to connection point
        //         //UpdateWire(collider.transform.position, false);
        //         snap_target = collider.transform;
        //         return;
        //     }
        // }

        // Update the wire
        UpdateWire(transform.position, false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check for nearby connection points for snapping
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 50f);
        foreach (Collider2D collider in colliders)
        {
            // Check if not self
            if (collider.gameObject != gameObject)
            {
                // Update wire to connection point
                //UpdateWire(collider.transform.position, false);
                snap_target = collider.transform;
                Debug.Log("Snap 1");

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    WireMatchingWinCondition.instance.IncrementCount(1);

                    collider.GetComponent<WireDragHandler>()?.Done();
                    Done();
                }

                break;
            }
        }

        // Check if snapping is required
        if (snap_target != null)
        {
            UpdateWire(snap_target.position, false);
            Debug.Log("Snap correct");
        }
        else
        {
            // Reset wire position
            UpdateWire(start_position, true);
            Debug.Log("Resetting");
        }
        // Reset wire position
        //UpdateWire(start_position, true);
    }

    private void Done()
    {
        light_on.SetActive(true);
        Destroy(this);
    }

    private void UpdateWire(Vector3 newPos, bool reset = false)
    {
        // Update moving wire's position
        //GetComponent<RectTransform>().anchoredPosition = newPos;

        transform.position = newPos;

        // if (reset == true)
        // {
        //     transform.position = newPos;
        // }

        // Update moving wire's direction
        Vector3 direction = transform.position - start_point;
        transform.right = direction * transform.lossyScale.x;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Update wire scale
        float distance = Vector3.Distance(start_point, transform.position);
        RectTransform wire_end_rect = wire_end.GetComponent<RectTransform>();
        wire_end_rect.sizeDelta = new Vector2(distance, wire_end_rect.sizeDelta.y);
        //transform.localScale = new Vector3(distance, wire_end.transform.localScale.y, wire_end.transform.localScale.z);
    }
}
