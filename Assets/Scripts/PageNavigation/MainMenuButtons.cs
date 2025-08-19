/**
 * MainMenuButtons.cs
 * 
 * This script contains the logic for the buttons in the main menu.
 * 
 * @author Austin Hwang
 * @date 20 August 2025
 */
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour, IPointerClickHandler
{
    public enum main_menu_button
    {
        Start,
        Quit
    }

    [SerializeField]
    private main_menu_button current_button_type;
    [SerializeField]
    private Object scene_to_load;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (current_button_type)
        {
            case main_menu_button.Start:
                StartGame();
                break;
            case main_menu_button.Quit:
                Application.Quit();
                break;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(scene_to_load.name);
    }
}
