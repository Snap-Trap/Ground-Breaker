using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public MenuManager menuManager;

    // Websites pakken dus wrs google
#if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
#endif

    public void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            menuManager.OpenPauseMenu();
        }

        if (menuManager.MenuOpen)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                menuManager.ClosePauseMenu();
            }
        }
    }

    public void Resume()
    {
        menuManager.ClosePauseMenu();
    }

    public void Retry()
    {
        WinCheck.playerInWinbox = false;
        PlayerMovement.micDisabled = false;
        menuManager.ClosePauseMenu();
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }
}
