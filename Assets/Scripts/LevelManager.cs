using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;  // Assign buttons for all levels
    private bool[] unlockedLevels;
    private void Start()    
    {
        unlockedLevels = new bool[levelButtons.Length];
        unlockedLevels[0] = true;  // Unlock first level at start
        UpdateLevelButtons();
    }

    public void UnlockNextLevel(int currentLevel)
    {
        if (currentLevel < unlockedLevels.Length)
        {
            unlockedLevels[currentLevel] = true; // Unlock next level
            UpdateLevelButtons();
        }
    }

    private void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = unlockedLevels[i];
        }
    }
}
