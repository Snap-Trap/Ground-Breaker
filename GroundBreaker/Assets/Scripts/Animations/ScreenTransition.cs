using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    public Animator transition;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(LevelGoingLoading(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LevelGoingLoading(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
