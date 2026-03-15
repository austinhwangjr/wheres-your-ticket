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
        IssueType currentIssue = PageManager.instance.ticket_selected.issue_type;

        // IssueType currentIssue = IssueType.WifiNotOn;

        
        // Note: Maybe the ticket should have a private bool "desktop_opened_before" to track if the desktop has been opened before. If true, load existing desktop state. If false, load new desktop state.
        if (!PageManager.instance.ticket_selected.desktop_opened_before)
        {
            PageManager.instance.ticket_selected.desktop_opened_before = true;
            UserDesktopManager.instance.LoadDesktopForIssue(currentIssue);
        }
        else
        {
            UserDesktopManager.instance.LoadExistingDesktop();
        }
        // UserDesktopManager.instance.LoadDesktopForIssue(currentIssue);
    }
}
