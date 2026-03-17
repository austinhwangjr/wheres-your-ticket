/**
 * MainMenuButtons.cs
 * 
 * This script contains the logic for the buttons in the main menu.
 * 
 * @author Austin Hwang
 * @date 20 August 2025
 */
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour, IPointerClickHandler
{
    public enum main_menu_button
    {
        Start,
        Options,
        Quit
    }

    [SerializeField]
    private main_menu_button current_button_type;
    [SerializeField]
    private Object scene_to_load;
    [SerializeField]
    private GameObject options_menu;
    [SerializeField]
    private GameObject button_group;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (current_button_type)
        {
            case main_menu_button.Start:
                StartGame();
                break;
            case main_menu_button.Options:
                OpenOptions();
                break;
            case main_menu_button.Quit:
                #if UNITY_STANDALONE
                    Application.Quit();
                #endif
                #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
                #endif
                break;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(scene_to_load.name);
    }

    private void OpenOptions()
    {
        options_menu.SetActive(true);
        button_group.SetActive(false);
    }
}
