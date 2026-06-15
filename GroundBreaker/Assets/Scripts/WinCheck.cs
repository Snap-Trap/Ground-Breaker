using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public static bool playerInWinbox = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the winbox");
            playerInWinbox = true;
        }
    }
}
