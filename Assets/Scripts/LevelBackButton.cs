using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBackButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene("RaagSurScene");
    }
}
