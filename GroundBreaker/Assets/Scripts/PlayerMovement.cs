using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Stuff for the microphone upwards movement
    private AudioInputDetection audioInputDetection;
    private Rigidbody2D rb;

    public float loudnessThreshold;
    public float launchSpeed;

    // Stuff for the sideways gyroscope movement
    private Vector3 initialOrientation;
    private Vector3 gyroInput;
    private Vector3 rotation;
    public float sideSpeed;
    public float maxVelocity;
    private Quaternion gyroOffset = Quaternion.identity;

    void Awake()
    {
        Input.gyro.enabled = true;
        Input.compensateSensors = true;
    }

    public void Start()
    {
        rotation = Vector3.zero;

        Debug.LogWarning(SystemInfo.supportsAccelerometer);

        // initialOrientation = Input.gyro.attitude.eulerAngles;
        audioInputDetection = GetComponent<AudioInputDetection>();
        audioInputDetection.StartMicrophone();
        rb = GetComponent<Rigidbody2D>();

        if (SystemInfo.supportsGyroscope)
        {
            StartGyro();
            Debug.LogWarning("Gyroscope enabled.");
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }

        if (SystemInfo.supportsAccelerometer)
        {
            Debug.LogWarning("Accelerometer enabled.");
        }
    }

    public void Update()
    {
        MicrophoneMovement();
        GyroscopeMovement();
    }

    public void GyroscopeMovement()
    {
        float tilt = Input.acceleration.x;
        Debug.LogWarning(Input.acceleration);

        if (Mathf.Abs(tilt) < 0.05f)
        {
            tilt = 0f;
        }
        
        rb.linearVelocity = new Vector2(tilt * sideSpeed, rb.linearVelocity.y);
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    IEnumerator StartGyro()
    {
        Input.gyro.enabled = true;

        yield return new WaitForSeconds(0.5f);

        Debug.Log(Input.acceleration);
    }

    public void MicrophoneMovement()
    {
//#if UNITY_EDITOR
//        if (Keyboard.current.spaceKey.isPressed)
//        {
//            MobileDebug.Log("Microphone pretends to go brrrrrrrrrr");
//            rb.AddForce(Vector2.up * launchSpeed, ForceMode2D.Force);
//        }
//#endif

        if (audioInputDetection)
        {
            MobileDebug.Log("Microphone go brrrrrrrrrr");
            float loudness = audioInputDetection.GetLoudness();
            Debug.LogWarning($"Loudness: {loudness}"); // Verwijder dit later

            if (loudness > loudnessThreshold)
            {
                Debug.LogWarning($"Player is trying to move up: {loudness}");
                rb.AddForce(Vector2.up * launchSpeed, ForceMode2D.Force);
            }
        }
    }
}
