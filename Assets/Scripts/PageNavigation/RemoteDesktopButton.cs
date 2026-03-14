/**
 * RemoteDesktopButton.cs
 * 
 * This script calls the function to enable the remote desktop for the current user.
 * 
 * @author Austin Hwang
 * @date 13 March 2026
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoteDesktopButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject overlay;

    public void OnPointerClick(PointerEventData eventData)
    {
        overlay.SetActive(true);
        //IssueType currentIssue = TicketManager.instance.ActiveTicket.issueType;
        IssueType currentIssue = IssueType.WifiOnNoInternet;
        UserDesktopManager.instance.LoadDesktopForIssue(currentIssue);
    }
}
