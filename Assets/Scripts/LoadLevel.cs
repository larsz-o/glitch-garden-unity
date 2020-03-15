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
            int nextScene = currentSceneIndex++;
            SceneManager.LoadScene(nextScene);
    }
    IEnumerator WaitForTime()
    {
            yield return new WaitForSeconds(timeToWait);
            LoadNextScene();

    }

   public void LoseLevel() 
   {
            SceneManager.LoadScene("End");
   }
}
