using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToHomePage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject event_system;

    private void Awake()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (event_system != null)
        {
            PageManager pm = event_system.GetComponent<PageManager>();
            if (pm != null)
            {
                pm.ShowHomePage();
            }
        }
    }
}
