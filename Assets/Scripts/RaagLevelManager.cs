using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaagLevelSelectManager : MonoBehaviour
{
    public Button[] raagLevelButtons;

    void Start()
    {
        int raagUnlocked = PlayerPrefs.GetInt("Raag_UnlockedLevel", 1);
        SetButtonStates(raagLevelButtons, raagUnlocked);
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
    public void ResetRaagProgress()
    {
        PlayerPrefs.DeleteKey("Raag_UnlockedLevel");
        PlayerPrefs.SetInt("Raag_UnlockedLevel", 1); // Optional: start fresh at level 1
        PlayerPrefs.Save();
        Debug.Log("Raag progress reset.");
    }

}