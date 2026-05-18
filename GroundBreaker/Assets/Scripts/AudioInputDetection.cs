using UnityEngine;
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
            // Luca: ShouldShowRequest doet dus die message die je wat meer info geeft voor WAAROM, gebruik deze inplaats van de normale request
            if (Permission.ShouldShowRequestPermissionRationale(Permission.Microphone))
            {
                Debug.Log("This super cool awesome game uses your microphone for the movement, please allow.");
            }
            // Permission.RequestUserPermission(Permission.Microphone);
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

    // Zorgt ervoor dat de audio
    public float GetLoudness()
    {
        if (microphoneClip == null) return 0f;

        int sampleWindow = 128;
        int micPosition = Microphone.GetPosition(microphoneDevice) - sampleWindow;
        if (micPosition < 0) return 0f;

        float[] samples = new float[sampleWindow];
        microphoneClip.GetData(samples, micPosition);

        float loudness = 0f;
        foreach (float sample in samples)
            
        loudness += Mathf.Abs(sample);

        return loudness / sampleWindow;
    }
}
