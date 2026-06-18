using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void ClickedSelectedLevel(int levelIndex)
    {
        if (GetComponent<LevelLockCheck>().CanGoToLevel(levelIndex))
        {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
