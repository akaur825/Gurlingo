using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button[] raagLevelButtons;
    public Button[] surLevelButtons;

    void Start()
    {
        int raagUnlocked = PlayerPrefs.GetInt("Raag_UnlockedLevel", 1);
        int surUnlocked = PlayerPrefs.GetInt("Sur_UnlockedLevel", 1);

        SetButtonStates(raagLevelButtons, raagUnlocked);
        SetButtonStates(surLevelButtons, surUnlocked);
    }

    void SetButtonStates(Button[] buttons, int unlockedLevel)
    {
        if (buttons == null) return;

        for (int i = 0; i < buttons.Length; i++)
        {
            bool isUnlocked = (i + 1) <= unlockedLevel;
            buttons[i].interactable = isUnlocked;

            // Look for LockIcon inside the button
            Transform lockIcon = buttons[i].transform.Find("LockIcon");
            if (lockIcon != null)
                lockIcon.gameObject.SetActive(!isUnlocked); // Show lock if locked
        }
    }
}
