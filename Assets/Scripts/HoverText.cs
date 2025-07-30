using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //TextMeshPro textmeshpro;
    public SpriteRenderer bg_sprite_renderer;
    public TextMeshPro text_tmp;
    public Color initial_bg_color;
    public Color hover_bg_color;
    public Color initial_text_color;
    public Color hover_text_color;

    public void OnPointerEnter(PointerEventData eventData)
    {
        bg_sprite_renderer.color = hover_bg_color;
        text_tmp.color = hover_text_color;
        //GetComponent<TextMeshPro>().color = Color.cyan;
        //GetComponent<TextMeshPro>().fontStyle = FontStyles.Underline;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bg_sprite_renderer.color = initial_bg_color;
        text_tmp.color = initial_text_color;
        //GetComponent<TextMeshPro>().color = Color.black;
        //GetComponent<TextMeshPro>().fontStyle = FontStyles.Normal;
    }
}
