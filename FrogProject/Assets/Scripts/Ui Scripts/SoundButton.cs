using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    Toggle soundToggle;

    private void Start()
    {
        soundToggle = GetComponent<Toggle>();
        soundToggle.onValueChanged.AddListener(Sound_On_Off);
    }

    //Event function called from SoundDisable Animation
    public void Disapear()
    {
        gameObject.SetActive(false);
    }

    //Listener to this gameObject toggle. Turns on ans off the sound
    public void Sound_On_Off(bool soundOn)
    {
        //TODO: llamar a funcion del Audio Manager (pasarle el bool?)
    }
}
