using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    Toggle toggle;

    public UITweening soundToggle;
    public UITweening musicToggle;

    
    UITweening pauseUi;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        pauseUi = GetComponent<UITweening>();


        toggle.onValueChanged.AddListener(Move);
        toggle.onValueChanged.AddListener(Resize);
        toggle.onValueChanged.AddListener(GameManager._intance.PauseGame);
    }




    //dynamico con el toggle
    public void Move(bool move)
    {
        MoveUi(move, musicToggle);
        MoveUi(move, soundToggle);
    }

    public void Resize(bool resize)
    {
        ResizeUI(resize, pauseUi);
    }

 
    void MoveUi(bool move,UITweening uITweening)
    {
        if (move)
        {
            uITweening.target_movement = uITweening.endPosition;
            uITweening.activate_begining = true;
            uITweening.deactivate_ending = false;
        }
        else
        {
            uITweening.target_movement = uITweening.startPosition;
            uITweening.deactivate_ending = true;
        }

        if (!uITweening.isrunning_movement) StartCoroutine(uITweening.MoveUI());
    }

    public void ResizeUI(bool resize, UITweening uITweening)
    {
        if (resize)
        {
            uITweening.target_size = uITweening.endSize;

      
        }
        else
        {
            uITweening.target_size = uITweening.startSize;
           
        }

        if (!uITweening.isrunning_scale) StartCoroutine(uITweening.ResizeUI());
    }

}
