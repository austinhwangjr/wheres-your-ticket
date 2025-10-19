/**
 * OverlapCircleVisualizer.cs
 * 
 * This test script draw a guizmo to visualise the collision radius for the wire-matching game.
 * 
 * @author Austin Hwang
 * @date 19 October 2025
 */
using UnityEngine;

public class OverlapCircleVisualizer : MonoBehaviour
{
    [SerializeField]
    private float radius = 0.2f;
    [SerializeField]
    private Color gizmoColor = Color.yellow;
    [SerializeField]
    private bool showWhilePlaying = true;

    private void OnDrawGizmos()
    {
        // Only draw in edit mode or when allowed during play
        if (!Application.isPlaying || showWhilePlaying)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}