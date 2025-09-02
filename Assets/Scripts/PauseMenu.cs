using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField]
    private GameObject pause_menu;
    [SerializeField]
    private GameObject audio_menu;
    private PlayerInput player_input;

    //-----Player input setup-----//
    private void Awake()
    {
        player_input = new PlayerInput();
    }

    private void OnEnable()
    {
        player_input.UI.Enable();
    }

    private void OnDisable()
    {
        player_input.UI.Disable();
    }

    //-----Pause menu setup-----//
    void Start()
    {
        pause_menu.SetActive(false);
    }

    void Update()
    {
        if (player_input.UI.Escape.triggered)
        {
            Debug.Log("Escape");
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //-----Pause menu buttons-----//
    public void Resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenuScene");  // For future main menu
    }

    public void Quit()
    {
        Application.Quit();
    }
}
