using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButtons : MonoBehaviour
{

    public Sprite flieNotTaken;
    public Sprite flieTaken;

    public int level;

    public Image[] flies = new Image[3];


    private void OnEnable()
    {
        //Change the sprite of the taken level's flies 
        bool[] gmflies = GameManager._intance.GetFliesOfLevels(level);

        for (int i = 0; i < flies.Length; i++)
        {
            if(gmflies[i])
                flies[i].sprite = flieTaken;
            else
                flies[i].sprite = flieNotTaken;

        }
    }

    public void GoToLevel()
    {
        GameManager._intance.StartLevel(level);
    }
}
