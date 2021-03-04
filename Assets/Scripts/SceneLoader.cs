using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 3)
            Destroy(gameObject);
            SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
