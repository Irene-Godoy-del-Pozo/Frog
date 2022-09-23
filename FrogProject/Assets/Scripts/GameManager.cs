using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _intance { get; private set; }
     
    [SerializeField]
    private int maxHealth;              //Max player's health

    public int GetMaxHealth() { return maxHealth; }

    public Level currentLevel;          //Current Level in display  

    public GameObject playerPref;       

    public InputManager inputManager;

    public GameObject mainMenu;         //Main Menu Canvas

    public GameObject pauseMenu;        //Pause Menu Canvas

    public GameObject levelMenu;        //Level Menu Canvas

    public bool gamePaused = false;

     
    [SerializeField]
    public List<LevelInfo> levelList = new List<LevelInfo>();  //Levels List

 
    private void Awake()
    {
        if (_intance != null && _intance != this)
        {
            Destroy(this);
            return;
        }
        _intance = this;

        DontDestroyOnLoad(transform.gameObject);

        inputManager.player = Instantiate(playerPref);
        inputManager.player.SetActive(false);

        int levelsInicialize = 0;
        SaveManager.LoadSave(levelList, out levelsInicialize);
        DefaultLevelInitialitation(levelsInicialize);
       
     
    }

    public void DeleteSaves()
    {
        SaveManager.DeleteAllSaves();
        DefaultLevelInitialitation(0);
    }

    #region Level Control

    //Initialize the levels to default state (Unfinished and 0 flies taken)
    protected void DefaultLevelInitialitation (int index)
    {      
       
        for (; index < levelList.Count; index++)
        {
            levelList[index].set_Name(levelList[index].lvl_Prefab.name + "(Clone)");
            levelList[index].lvl_Finished = false;
            levelList[index].initialize();
        }
    }

   
    public void LevelFinished(Level level)
    {

        //Update info saved in the level info 
        foreach (LevelInfo _levelinfo in levelList)
        {
            //Get the level info equals to level given 
            if (string.Equals(_levelinfo.get_Name(), level.gameObject.name))
            {
                _levelinfo.lvl_Finished = true;

                for (int i = 0; i < level.flies.Count; i++)
                {
                    _levelinfo.setFlies(i, !level.flies[i].gameObject.activeSelf);                  
                }

                level.gameObject.SetActive(false);
                Destroy(level.gameObject);

                inputManager.player.SetActive(false);

                LevelSelectionMenu();

                break;
            }
        }

       SaveManager.SaveData(levelList);

        Debug.Log(Application.persistentDataPath);

        PauseGame(false);
    }

    public void StartLevel(int index)
    {

        levelMenu.SetActive(false);

        
        ActivateFlies(levelList[index], levelList[index].lvl_Finished);
        
        //Create the corresponding level and assign it to the currentlevel variable  
        GameObject level = Instantiate(levelList[index].lvl_Prefab);
        currentLevel = level.GetComponent<Level>();
        currentLevel.SetPlayer(inputManager.player);

        //Set active the inputmanager to allow players control
        inputManager.gameObject.SetActive(true);

    }

    //Activate or Deactivate flies gameobject given the level info 
    private void ActivateFlies(LevelInfo levelInfo, bool isPassed) 
    {
        Level level = levelInfo.lvl_Prefab.GetComponent<Level>();

        //Set Active according to information stored in level info
        if(isPassed)
        {
            for (int i = 0; i < levelInfo.getFlies().Length; i++)
            {
                level.flies[i].gameObject.SetActive(!levelInfo.getFlies()[i]);
            }
        }
        //Set active true to all the flies on the level
        else
        {
            for (int i = 0; i < level.flies.Count; i++)
            {
                level.flies[i].gameObject.SetActive(true);
            }
        }
    }

    //Return the flies taken of a level
    public bool[] GetFliesOfLevels(int level)
    {
        if (!levelList[level].lvl_Finished) return new bool[] { false, false, false };
        return levelList[level].getFlies();
    }

    #endregion

    #region Menu Control

    //Show the Level selection Menu
    public void LevelSelectionMenu()
    {
        
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        pauseMenu.SetActive(true);
        inputManager.gameObject.SetActive(false);
   
    }

    
    public void PauseGame(bool isPaused)
    {
        gamePaused = isPaused;
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }


    public void BackToLevelsMenu()
    {
        //Only if there are a level 
        if (currentLevel)
        {
            currentLevel.gameObject.SetActive(false);
            Destroy(currentLevel.gameObject);

            inputManager.player.SetActive(false);

            PauseMenu.SetValuePauseToggle(false);

            LevelSelectionMenu();
        }
    }


    #endregion

}

