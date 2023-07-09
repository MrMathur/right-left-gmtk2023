using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject instance;
   private GameObject playerVisionCanvas;
    [SerializeField] GameObject soundButton;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

   void Start() {
        if (EnvironmentState.play_music) {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = soundOn;
        } else {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = soundOff;
        }
   }

    public void Pause() {
        instance.SetActive(true);
        playerVisionCanvas = GameObject.FindWithTag("PlayerVisionCanvas");
        playerVisionCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume() {
        instance.SetActive(false);
        Time.timeScale = 1f;
        playerVisionCanvas.SetActive(true);
    }

    public void GoHome() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        EnvironmentState.curr_level = 2;
    }

      public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void  MusicToggle() {
        EnvironmentState.ToggleMusic();
        if (EnvironmentState.play_music) {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = soundOn;
        } else {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = soundOff;
        }

    }   
}
