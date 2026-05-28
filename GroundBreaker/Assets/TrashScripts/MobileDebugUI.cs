using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class MobileDebugUI : MonoBehaviour
{
    public static MobileDebugUI Instance;

    private List<string> logList = new List<string>();

    [SerializeField] private TMP_Text debugText;

    private string fullLog = "";

    private void Awake()
    {
        Instance = this;
    }

    public void AddLog(string message)
    {
        Debug.Log(message);

        logList.Add(message);

        if (logList.Count > 10)
        {
            logList.RemoveAt(0);
        }

        foreach (string log in logList)
        {
            fullLog += log + "\n";
        }

        fullLog += message + "\n";

        debugText.text = fullLog;
    }
}
