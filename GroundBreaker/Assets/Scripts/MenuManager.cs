using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool menuAlreadyOpen;

    public void Start()
    {
        menuAlreadyOpen = false;
    }

    public void MenuCheck(GameObject menuObject)
    {
        menuObject.gameObject.SetActive(false);
    }
}
