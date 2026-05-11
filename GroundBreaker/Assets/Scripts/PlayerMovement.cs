using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private AudioInputDetection audioInputDetection;
    private Rigidbody2D rb;

    public float loudnessThreshold = 0.007f;
    public float launchSpeed = 100f;

    public void Start()
    {
        audioInputDetection = GetComponent<AudioInputDetection>();
        audioInputDetection.StartMicrophone();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
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
