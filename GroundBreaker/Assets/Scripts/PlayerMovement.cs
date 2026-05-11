using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void Start()
    {
        rotation = Vector3.zero;

        Debug.Log(SystemInfo.supportsAccelerometer);
        Debug.Log(Input.acceleration);

        initialOrientation = Input.gyro.attitude.eulerAngles;
        audioInputDetection = GetComponent<AudioInputDetection>();
        audioInputDetection.StartMicrophone();
        rb = GetComponent<Rigidbody2D>();

        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    public void FixedUpdate()
    {
        MicrophoneMovement();
        GyroscopeMovement();
    }

    public void GyroscopeMovement()
    {
        //// Attitude zorgt voor de tilt
        float tilt = Input.gyro.attitude.eulerAngles.z;
        //// Onderscheid maken tussen -180 en 180 graden want rekenen
        if (tilt > 180f) tilt -= 360f;

        //rotation.z = Input.gyro.rotationRateUnbiased.z;
        //rotation.x = -Input.gyro.rotationRateUnbiased.x;
        //.attitude = orientation in space
        //transform.rotation = Input.gyro.attitude;

        //transform.Rotate(rotation.x, 0, rotation.z);
        Debug.LogWarning($"Rotation: {tilt}");

        // Onderscheidt maken tussen links en rechts voor beweging
        float horizontalInput = Input.acceleration.z;


        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            //rb.linearVelocity = new Vector2(horizontalInput * sideSpeed, rb.linearVelocity.y);
            rb.AddForce(Vector2.right * horizontalInput * sideSpeed, ForceMode2D.Force);
        }
    }

    public void MicrophoneMovement()
    {
#if UNITY_EDITOR
        if (Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(Vector2.up * launchSpeed, ForceMode2D.Force);
        }
#endif

        if (audioInputDetection)
        {
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
