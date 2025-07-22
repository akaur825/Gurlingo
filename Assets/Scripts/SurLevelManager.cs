using UnityEngine;
using UnityEngine.UI;

public class SurLevelSelectManager : MonoBehaviour
{
    public Button[] surLevelButtons;

    void Start()
    {
        int surUnlocked = PlayerPrefs.GetInt("Sur_UnlockedLevel", 1);
        SetButtonStates(surLevelButtons, surUnlocked);
    }

    void SetButtonStates(Button[] buttons, int unlockedLevel)
    {
        if (buttons == null) return;

        for (int i = 0; i < buttons.Length; i++)
        {
            bool isUnlocked = (i + 1) <= unlockedLevel;
            buttons[i].interactable = isUnlocked;

            Transform lockIcon = buttons[i].transform.Find("lock");
            if (lockIcon != null)
                lockIcon.gameObject.SetActive(!isUnlocked);
        }
    }
}
