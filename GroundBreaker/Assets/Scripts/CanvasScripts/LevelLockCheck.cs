using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelLockCheck : MonoBehaviour
{
    // Need a check for level access, level 1 is always unlocked hence no bool for that one
    // Update if I need more
    private List<bool> levelUnlocks = new List<bool>() { true, false, false, false, false, false, false };
    public static int NextLevelToUnlock;

    public void Awake()
    {
        if (NextLevelToUnlock > 0)
        {
            UnlockLevel(NextLevelToUnlock);
            NextLevelToUnlock = 0;
        }
    }

    internal bool CanGoToLevel(int levelIndex)
    {
        int index = levelIndex - 1;
        if (index < levelUnlocks.Count)
        {
            return levelUnlocks[index];
        }
        else
        {
            Debug.LogError("Level index out of range: " + levelIndex);
            return false;
        }
    }

    internal void UnlockLevel(int levelIndex)
    {
        int index = levelIndex - 1;
        if (index >= 0 && index < levelUnlocks.Count)
        {
            levelUnlocks[index] = true;
        }
        else
        {
            Debug.LogError("Level index out of range: " + levelIndex);
        }
    }
}
