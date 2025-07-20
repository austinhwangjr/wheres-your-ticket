using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //TextMeshPro textmeshpro;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<TextMeshPro>().color = Color.cyan;
        GetComponent<TextMeshPro>().fontStyle = FontStyles.Underline;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<TextMeshPro>().color = Color.black;
        GetComponent<TextMeshPro>().fontStyle = FontStyles.Normal;
    }
}
