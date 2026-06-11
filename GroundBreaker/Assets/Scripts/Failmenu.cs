using System.Collections;
using TMPro;
using UnityEngine;

public class FailMenu : MonoBehaviour
{
    public MenuManager menuManager;

    public TextMeshProUGUI failText;

    private bool FailTimerStarted;
    public void Update()
    {
        ShowFailMenu();
    }

    public void ShowFailMenu()
    {
        if (!PlayerBarrierCheck.barrierIsHit) return;

        if (!FailTimerStarted)
        {
            if (PlayerBarrierCheck.barrierIsBroken == false)
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
