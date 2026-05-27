using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Failmenu : MonoBehaviour
{
    public GameObject FailMenuUI;

    // Websites pakken dus wrs google
#if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
#endif

    public void OpenMenu()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            FailMenuUI.gameObject.SetActive(true);
        }
    }

    public void Resume()
    {
        FailMenuUI.gameObject.SetActive(false);
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
