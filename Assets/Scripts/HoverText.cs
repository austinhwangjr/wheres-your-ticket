using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //TextMeshPro textmeshpro;
    public SpriteRenderer bg_sprite_renderer;
    public Image bg_image;
    public TextMeshProUGUI text_tmp;
    public Color initial_bg_color;
    public Color hover_bg_color;
    public Color initial_text_color;
    public Color hover_text_color;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (bg_sprite_renderer != null)
        {
            bg_sprite_renderer.color = hover_bg_color;
        }
        if (bg_image != null)
        {
            bg_image.color = hover_bg_color;
        }
        if (text_tmp != null)
        {
            text_tmp.color = hover_text_color;
        }
        
        //GetComponent<TextMeshPro>().color = Color.cyan;
        //GetComponent<TextMeshPro>().fontStyle = FontStyles.Underline;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (bg_sprite_renderer != null)
        {
            bg_sprite_renderer.color = initial_bg_color;
        }
        if (bg_image != null)
        {
            bg_image.color = initial_bg_color;
        }
        if (text_tmp != null)
        {
            text_tmp.color = initial_text_color;
        }
        //GetComponent<TextMeshPro>().color = Color.black;
        //GetComponent<TextMeshPro>().fontStyle = FontStyles.Normal;
    }
}
