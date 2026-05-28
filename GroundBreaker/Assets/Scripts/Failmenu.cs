using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Failmenu : MonoBehaviour
{
    public InputAction openMenu;

    public GameObject FailMenuUI;

    // Websites pakken dus wrs google
#if UNITY_WEBPLAYER
    public static string webplayerQuitURL = "http://google.com";
#endif

    public void Start()
    {
        FailMenuUI.gameObject.SetActive(false);
    }

    public void Update()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        if (FailMenuUI.activeSelf == false)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                FailMenuUI.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                FailMenuUI.gameObject.SetActive(false);
            }
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
