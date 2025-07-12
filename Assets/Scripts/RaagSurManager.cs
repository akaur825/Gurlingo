using UnityEngine;
using UnityEngine.SceneManagement;

public class RaagSurManager : MonoBehaviour
{
    public void LoadRaagScene()
    {
        SceneManager.LoadScene("RaagLevelScene");
    }

    public void LoadSurScene()
    {
        SceneManager.LoadScene("SurLevelScene");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
