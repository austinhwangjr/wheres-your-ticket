using UnityEngine;
using UnityEngine.EventSystems;

public class ClickNavigate : MonoBehaviour, IPointerClickHandler
{
    public GameObject to_enable;
    public GameObject to_disable;

    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        to_enable.SetActive(true);
        to_disable.SetActive(false);
    }
}
