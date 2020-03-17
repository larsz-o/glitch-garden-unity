using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
  [SerializeField] float levelTimeInSeconds = 10f;
  bool timerFinished = false; 
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad/levelTimeInSeconds;
        timerFinished = (Time.timeSinceLevelLoad > levelTimeInSeconds);
        if (timerFinished)
        {
            Debug.Log("Time's up");
        }
    }
    public bool GetGameTimer()
    {
       return timerFinished;
    }
}
