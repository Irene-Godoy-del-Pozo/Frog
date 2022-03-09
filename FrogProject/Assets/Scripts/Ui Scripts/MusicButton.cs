using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    Toggle musicToggle;

 
    private void OnEnable()
    {
        musicToggle = GetComponent<Toggle>();
        musicToggle.onValueChanged.AddListener(Music_On_Off);
    }
    private void OnDisable()
    {
        musicToggle.onValueChanged.RemoveListener(Music_On_Off);
    }
    //Event function called from MusicDisable Animation
    public void Disapear( )
    {
        gameObject.SetActive(false);
    }

    //Listener to Onvaluechanged of PauseMenu toggle. Play an animation given a bool
    public void PauseActivate(bool gamePaused)
    {
        if(gamePaused)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<Animator>().Play("MusicEnable");
        }
        else
            gameObject.GetComponent<Animator>().Play("MusicDisable");
    }


    //Listener to this gameObject toggle. Turns on ans off the music
    public void Music_On_Off(bool musicOn)
    {
        //TODO: llamar a funcion del Audio Manager (pasarle el bool?)
    }

}
