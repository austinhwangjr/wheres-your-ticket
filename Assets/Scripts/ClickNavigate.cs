using UnityEngine;
using UnityEngine.EventSystems;

public class ClickNavigate : MonoBehaviour, IPointerClickHandler
{
    public GameObject source;
    public GameObject destination;
    public GameObject tickets_list;

    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        source.SetActive(false);
        destination.SetActive(true);

        if (tickets_list != null)
        {
            tickets_list.SetActive(!tickets_list.activeSelf);
        }
    }
}
