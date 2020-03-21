using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTimeInSeconds = 30f;
    [SerializeField] Text timerText;
    Image timerImage;
    bool timerStillWorking = true;
    float currentTime;
    void Start()
    {
        currentTime = levelTimeInSeconds;
        timerImage = GetComponent<Image>();
        timerImage.fillAmount = 1.0f;
        timerText.text = (levelTimeInSeconds.ToString("#") + "s");
    }
    void Update()
    {
        if (timerStillWorking)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f) 
            {
                EndTimer();
                timerText.text = "Finish them!";
            } else {
            timerText.text = (currentTime.ToString("#") + "s");
            float normalizedValue = Mathf.Clamp(currentTime/levelTimeInSeconds, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            }
           
        }
    }
    private void EndTimer()
    {
        timerStillWorking = false;
        FindObjectOfType<LevelController>().TimerLevelFinished();
    }
}
