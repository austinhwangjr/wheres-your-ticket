/**
 * Draggable.cs
 * 
 * This script contains logic to handle GameObject drag-and-drop.
 * Raycast is used to check the object that is clicked.
 * 
 * @author Austin Hwang
 * @date 20 July 2025
 */
using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private PlayerInput player_input;
    private bool dragging = false;
    private Vector3 offset;

    private void Awake()
    {
        player_input = new PlayerInput();
    }

    private void OnEnable()
    {
        player_input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        player_input.Gameplay.Disable();
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = transform.position.z;

        if (player_input.Gameplay.LeftMouse.triggered)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if (hit.collider != null && hit.transform == transform)
            {
                dragging = true;
                offset = transform.position - mouseWorldPos;
            }
        }

        if (player_input.Gameplay.LeftMouse.WasReleasedThisFrame())
        {
            dragging = false;
        }

        if (dragging)
        {
            transform.position = mouseWorldPos + offset;
        }
    }
}
