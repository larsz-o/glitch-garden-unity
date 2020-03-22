using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    int currentSceneIndex;
    int timeToWait = 6;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

    }
    public void LoadNextScene()
    {
            int nextScene = currentSceneIndex + 1;
            SceneManager.LoadScene(nextScene);
    }
    IEnumerator WaitForTime()
    {
            yield return new WaitForSeconds(timeToWait);
            LoadNextScene();
    }

   public void WinGame() 
   {
        SceneManager.LoadScene("End");
   }
   public void NavToMainMenu()
   {
        Time.timeScale = 1f;
       SceneManager.LoadScene(1);
   }
   public void NavToSettings()
   {
       SceneManager.LoadScene("Settings");
   }
   public void RestartLevel()
   {
        Time.timeScale = 1f;
       SceneManager.LoadScene(currentSceneIndex);
   }
   public void QuitGame()
   {
       Application.Quit();
   }
}
