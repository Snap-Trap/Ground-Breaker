using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MenuManager
{
    public GameObject PauseMenuUI;

    // Websites pakken dus wrs google
#if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
#endif

    public new void Start()
    {
        MenuCheck(PauseMenuUI);
    }

    public void Update()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        if (menuAlreadyOpen) return;

        if (PauseMenuUI.activeSelf == false)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                PauseMenuUI.gameObject.SetActive(true);
                menuAlreadyOpen = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                PauseMenuUI.gameObject.SetActive(false);
                menuAlreadyOpen = false;
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.gameObject.SetActive(false);
    }


    public void Retry()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL)
#else
        Application.Quit()
#endif
    }
}
