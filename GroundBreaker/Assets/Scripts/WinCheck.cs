using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public static bool playerInWinbox = false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetWinState;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetWinState;
    }

    private static void ResetWinState(Scene scene, LoadSceneMode mode)
    {
        playerInWinbox = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the winbox");
            playerInWinbox = true;
        }
    }
}
