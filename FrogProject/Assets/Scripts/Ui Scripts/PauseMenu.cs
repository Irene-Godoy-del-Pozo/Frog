using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    static Toggle toggle;

    public UITweening soundToggle;
    public UITweening musicToggle;
    public UITweening backToggle;
     
    UITweening pauseUi;
    
    
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        pauseUi = GetComponent<UITweening>();

        
        toggle.onValueChanged.AddListener(Move);
        toggle.onValueChanged.AddListener(Resize);
        toggle.onValueChanged.AddListener(GameManager._intance.PauseGame);
    }

    public static void SetValuePauseToggle(bool value)
    {
        toggle.isOn = value;
    }


    //dynamic function to move the ui
    public void Move(bool move)
    {
        MoveUi(move, musicToggle);
        MoveUi(move, soundToggle);
        MoveUi(move, backToggle);
    }


    //dynamic function to resize the ui
    public void Resize(bool resize)
    {
        ResizeUI(resize, pauseUi);
    }

 
    void MoveUi(bool move,UITweening uITweening)
    {
        //Settup options for the movement
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

        //Avoid call the corutine if is running
        if (!uITweening.isrunning_movement) StartCoroutine(uITweening.MoveUI());
    }

    public void ResizeUI(bool resize, UITweening uITweening)
    {
        //Settup options for the resize
        if (resize)
        {
            uITweening.target_size = uITweening.endSize;
    
        }
        else
        {
            uITweening.target_size = uITweening.startSize;
           
        }
        //Avoid call the corutine if is running
        if (!uITweening.isrunning_scale) StartCoroutine(uITweening.ResizeUI());
    }

}
