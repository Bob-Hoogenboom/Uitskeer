using UnityEngine;
using UnityEngine.SceneManagement;

public class BenefitMenu : MonoBehaviour
{
    public void LoadForumScene(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }
}
