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
    public void ResetProgress()
    {
        Debug.Log("Reset was called!");
        PlayerPrefs.SetInt("Raag_UnlockedLevel1", 1);
        PlayerPrefs.SetInt("Sur_UnlockedLevel1", 1);
        PlayerPrefs.Save();

        Debug.Log("Progress reset!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}