using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    Toggle toggle;

    public SoundButton soundToggle;
    public MusicButton musicToggle;

  
    

    private void Start()
    {
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(musicToggle.PauseActivate);
        toggle.onValueChanged.AddListener(soundToggle.PauseActivate);
        //toggle.onValueChanged.AddListener(PauseGame);
    }


    void PauseGame(bool isPaused)
    {
        //TODO: HACERLO FUNCION DEL GAMEMANAGER

        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }



}
