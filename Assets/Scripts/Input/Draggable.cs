using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Mouse.current == null) return; // Ensure a mouse is connected

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = transform.position.z; // Keep original Z (for 3D compatibility)

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                dragging = true;
                offset = transform.position - mouseWorldPos;
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }

        if (dragging)
        {
            transform.position = mouseWorldPos + offset;
        }
    }

    // void Update()
    // {
    //     if (dragging)
    //     {
    //         transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    //     }
    // }

    // private void OnMouseDown()
    // {
    //     dragging = true;
    //     offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    // }

    // private void OnMouseUp()
    // {
    //     dragging = false;
    // }
}
