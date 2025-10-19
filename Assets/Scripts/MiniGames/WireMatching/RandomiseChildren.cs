/**
 * RandomiseChildren.cs
 * 
 * This script contains the logic to randomise the wire order (for the wire-matching game).
 * 
 * @author Austin Hwang
 * @date 20 October 2025
 */
using UnityEngine;

public class RandomiseChildren : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            // Select random index in range
            int newIndex = Random.Range(0, transform.childCount);

            // Swap positions
            Vector3 tempPos = transform.GetChild(i).position;
            transform.GetChild(i).position = transform.GetChild(newIndex).position;
            transform.GetChild(newIndex).position = tempPos;
        }
    }
}
