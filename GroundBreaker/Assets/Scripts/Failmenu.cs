using System.Collections;
using UnityEngine;

public class FailMenu : MonoBehaviour
{
    public MenuManager menuManager;

    private bool FailTimerStarted;
    public void Update()
    {
        ShowFailMenu();
    }

    public void ShowFailMenu()
    {
        if (!Breakpoint.barrierIsHit) return;

        if (!FailTimerStarted)
        {
            if (Breakpoint.barrierIsBroken == false)
            {
                FailTimerStarted = true;
                StartCoroutine(DelayFail(4f));
            }
        }
    }

    private IEnumerator DelayFail(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        menuManager.OpenFailMenu();
    }
}
