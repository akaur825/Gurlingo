using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIController : MonoBehaviour
{
    public Dropdown ScaleDropdown;     // Assign in Inspector
    public Button Button;              // Your "Let's Go" button

    void Start()
    {
        // Attach click listener
        Button.onClick.AddListener(OnLetsGoClicked);
    }

    void OnLetsGoClicked()
    {
        string selectedScale = ScaleDropdown.options[ScaleDropdown.value].text;

        // Store it globally (simple example using PlayerPrefs)
        PlayerPrefs.SetString("SelectedScale", selectedScale);
        PlayerPrefs.Save();

        Debug.Log("Selected Scale: " + selectedScale);

        // Load the next scene (set this to whatever your training selection scene is called)
        SceneManager.LoadScene("RaagSurScene"); // Change this to match your actual scene name
    }
}
