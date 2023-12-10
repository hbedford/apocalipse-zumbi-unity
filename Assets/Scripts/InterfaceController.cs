using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InterfaceController : MonoBehaviour
{
    private PlayerController playerController;
    public Slider SliderPlayerLife;
    public GameObject GameOverPanel;
    public TMP_Text TextTimeSurvived;
    public TMP_Text TextMaxTimeSurvived;
    public float maxTimeSurvived;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SliderPlayerLife.maxValue = playerController.statusController.Health;
        UpdateLife();
        Time.timeScale = 1;
        maxTimeSurvived = PlayerPrefs.GetFloat("MaxTimeSurvived", 0);

    }


    public void UpdateLife()
    {
        SliderPlayerLife.value = playerController.statusController.Health;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;

        int minutes = getMinutes(Time.timeSinceLevelLoad);
        int seconds = getSeconds(Time.timeSinceLevelLoad);
        TextTimeSurvived.text = "Voce sobreviveu por "+minutes.ToString("00") + "minutos e " + seconds.ToString("00") + " segundos";
        adjustMaxTimeSurvived(minutes,seconds);


    }

    void adjustMaxTimeSurvived(int minutes,int seconds)
    {
        if(Time.timeSinceLevelLoad > maxTimeSurvived)
        {
            maxTimeSurvived = Time.timeSinceLevelLoad;
            changeTextMaxTimeSurvived(minutes,seconds);
            PlayerPrefs.SetFloat("MaxTimeSurvived", maxTimeSurvived);
            return;
        }
        int minutesMax = getMinutes(maxTimeSurvived);
        int secondsMax = getSeconds(maxTimeSurvived);
        changeTextMaxTimeSurvived(minutesMax,secondsMax);
    }

     int getMinutes(float time)
    {
        return (int)time / 60;
    }
    int getSeconds(float time)
    {
            return (int)time % 60;
        }

    void changeTextMaxTimeSurvived(int minutes,int seconds)
    {
        TextMaxTimeSurvived.text = string.Format("Seu melhor tempo é {0}min e {1}s", minutes, seconds);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
