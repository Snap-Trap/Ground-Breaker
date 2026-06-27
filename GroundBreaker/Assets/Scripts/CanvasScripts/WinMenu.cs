using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public MenuManager menuManager;

    private bool WinTimerStarted;


    public void Update()
    {
        StartWinMenu();
    }

    public void StartWinMenu()
{
        if (WinCheck.playerInWinbox)
        {
            if (!WinTimerStarted)
            {
                StartCoroutine(DelayWinScreen());
            }
        }
    }

    public void NextLevel()
    {
        WinCheck.playerInWinbox = false ? true : false;
        menuManager.CloseWinMenu();
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        LevelLockCheck.NextLevelToUnlock = ++buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    private IEnumerator DelayWinScreen()
    {
        WinTimerStarted = true;
        yield return new WaitForSeconds(2f);
        menuManager.OpenWinMenu();
    }
}
