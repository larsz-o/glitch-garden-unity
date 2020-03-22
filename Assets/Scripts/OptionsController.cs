using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty = 1f;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
    }

    void Update()
    {
       SetVolume();
    }
   public void SaveAndExit()
   {
       PlayerPrefsController.SetMasterVolume(volumeSlider.value);
       PlayerPrefsController.SetMasterDifficulty(difficultySlider.value);
       FindObjectOfType<LoadLevel>().NavToMainMenu();
   }
   private void SetVolume()
   {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
   }
   public void ResetDefaults()
   {
       volumeSlider.value = defaultVolume;
       difficultySlider.value = defaultDifficulty;
   }
}
