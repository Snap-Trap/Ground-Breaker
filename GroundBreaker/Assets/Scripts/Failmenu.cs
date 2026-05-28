using System.Collections;
using UnityEngine;

public class FailMenu : MenuManager
{
    public GameObject FailMenuUI;

    public new void Start()
    {
        MenuCheck(FailMenuUI);
    }

    public void Update()
    {
        ShowFailMenu();
    }

    public void ShowFailMenu()
    {
        if (menuAlreadyOpen) return;

        if (Breakpoint.barrierIsBroken == false)
        {
            StartCoroutine(DelayFail(4f));
        }
    }

    private IEnumerator DelayFail(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (FailMenuUI.activeSelf == false)
        {
            FailMenuUI.SetActive(true);
            menuAlreadyOpen = true;
        }
        
    }
}
