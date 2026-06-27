using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    private Button button;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;
    private Color unlockedColor = Color.white;
    private Color lockedColor = Color.gray;

    private LevelLockCheck lockCheck;

    public void Start()
    {
        unlockedColor = buttonImage.color;

        lockCheck = FindFirstObjectByType<LevelLockCheck>();

        if (lockCheck == null)
        {
            Debug.LogError("No LevelLockCheck found in scene.");
            return;
        }

        RefreshButtonState();
    }

    public void RefreshButtonState()
    {
        bool unlocked = lockCheck.CanGoToLevel(levelIndex);

        button.interactable = unlocked;
        buttonImage.color = unlocked ? unlockedColor : lockedColor;
    }
}
