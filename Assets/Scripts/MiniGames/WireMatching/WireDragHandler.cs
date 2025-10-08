/**
 * WireDragHandler.cs
 * 
 * This script contains the logic for the wire-matching game.
 * Clicking on a wire will drag it.
 * 
 * @author Austin Hwang
 * @date 7 October 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class WireDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 start_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_position = transform.parent.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //lineRenderer.enabled = true;
        //lineRenderer.SetPosition(0, transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update moving wire's position on pointer drag
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition += eventData.delta;

        // Update moving wire's direction
        Vector3 direction = transform.position - start_position;
        transform.right = direction;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // // Raycast to check what was hit
        // if (eventData.pointerCurrentRaycast.gameObject != null)
        // {
        //     var target = eventData.pointerCurrentRaycast.gameObject.GetComponent<WireTarget>();
        //     if (target != null && target.colorName == colorName)
        //     {
        //         Debug.Log($"Matched {colorName}!");
        //         // Lock the line
        //         lineRenderer.SetPosition(1, target.transform.position);
        //         lineRenderer.startColor = Color.green;
        //         lineRenderer.endColor = Color.green;
        //         // Mark both as completed
        //     }
        //     else
        //     {
        //         Debug.Log("Wrong match!");
        //         lineRenderer.enabled = false;
        //     }
        // }
        // else
        // {
        //     lineRenderer.enabled = false;
        // }
    }
}
