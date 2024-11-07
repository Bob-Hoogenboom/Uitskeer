using UnityEngine;
using UnityEngine.SceneManagement;

public class BenefitMenu : MonoBehaviour
{
    public void LoadNextScene(int loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }
}
