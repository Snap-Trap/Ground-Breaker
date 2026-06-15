using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject FailMenuUI;
    public GameObject PauseMenuUI;
    public GameObject WinMenuUI;

    public bool MenuOpen => PauseMenuUI.activeSelf || FailMenuUI.activeSelf || WinMenuUI.activeSelf;

    public void OpenPauseMenu()
    {
        if (MenuOpen) return;

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenFailMenu()
    {
        if (MenuOpen) return;

        FailMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenWinMenu()
    {
        if (MenuOpen) return;

        WinMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePauseMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseFailMenu()
    {
        FailMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseWinMenu()
    {
        WinMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
