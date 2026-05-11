using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class AudioInputDetection : MonoBehaviour
{
    public int frequency = 44100;
    private string microphoneDevice;
    private AudioClip microphoneClip;

    public static void GetDeviceCaps(string deviceName, out int minFreq, out int maxFreq)
    {
        Microphone.GetDeviceCaps(deviceName, out minFreq, out maxFreq);
    }

    public void StartMicrophone()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        if (Microphone.devices.Length > 0)
        {
            microphoneDevice = Microphone.devices[0];
            microphoneClip = Microphone.Start(microphoneDevice, true, 2, frequency);
        }
        else
        {
            Debug.LogWarning("No microphone device found.");
        }
    }
}
