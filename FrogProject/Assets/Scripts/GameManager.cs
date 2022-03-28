using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    [Serializable]
    private class LevelInfo             //Relevant Information about the level
    {
        //Prefab
        public GameObject lvl_Prefab;

        //State of the level (Finished/Unfinished)
        public bool lvl_Finished;
        
        //Level Name
        string lvl_Name;
        public string get_Name() { return lvl_Name; }
        public void set_Name(string newName) { lvl_Name = newName; }

        //Array of level flies's state (Taken/Not taken)
        public bool[] flies_taken;

        public bool[] getFlies() { return flies_taken; }
        public void setFlies(int index, bool state) { flies_taken[index] = state; }
        public void initialize() { flies_taken = new bool[3]; }
    }
    
    [SerializeField]
    List<LevelInfo> levelList = new List<LevelInfo>();  //Levels List


    #region Save Data

    [Serializable]
    public class SaveInfo
    {      
        public bool lvl_Finished;

        public bool[] flies_taken;
    }

    [Serializable]
    public class SaveInfoList
    {
        public List<SaveInfo> savedataList;
    }

    int maxSaves = 9;       //Limit of files created as saves
    int currentsave = 0;    //Next file that is going to be created o modified 

    public void SaveData()
    {
        SaveInfoList datalist = new SaveInfoList();
        datalist.savedataList = new List<SaveInfo>();

        //Save the level state and the flies taken of each level into a SafeInfo variable
        foreach (LevelInfo _levelinfo in levelList)
        {
            //The levels can only be finished in order. If this level isnt finished, the function can stop searching.
            if (!_levelinfo.lvl_Finished) break;

            SaveInfo data = new SaveInfo();

           
            data.lvl_Finished = _levelinfo.lvl_Finished;
            data.flies_taken = new bool[_levelinfo.flies_taken.Length];
            data.flies_taken = _levelinfo.flies_taken;
            
            datalist.savedataList.Add(data);
           

        }

        //If the list is not empty , its converted to json and saved 
        if (datalist.savedataList.Count !=0)
        {
            string path = Path.Combine(Application.persistentDataPath, "save"+currentsave+".json");

            if (currentsave >= maxSaves)
                currentsave = 0;
            else
                currentsave++;

            Debug.Log(JsonUtility.ToJson(datalist));
           
            File.WriteAllText(path, JsonUtility.ToJson(datalist, true));
        }
    }



    void LoadSave()
    {
        SaveInfoList datalist = new SaveInfoList();
        datalist.savedataList = new List<SaveInfo>();

        try
        {
            
            DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
            
            //search the file that have the lastest write time. Also make sure that de char occupied in ? is an digit
            FileInfo lastFile = dir.GetFiles("save?.json").OrderByDescending(f => f.LastWriteTime).First(f => Char.IsDigit(f.Name,4));

            //Get the data from the file          
            string data = File.ReadAllText(lastFile.FullName);
            Debug.Log(lastFile.FullName);
            Debug.Log(data);

            //Transform the data into a SaveInfoList
            datalist = JsonUtility.FromJson<SaveInfoList>(data);
          
            LoadedLevelInitialitation(datalist.savedataList);

            //Get the number of the file that have the data and get the next one
            currentsave = (int)Char.GetNumericValue(lastFile.Name, 4);
            Debug.Log(currentsave);

            if (currentsave < maxSaves) currentsave++;
            else currentsave = 0;


        }
        catch(Exception e)
        {
            Debug.LogException(e);

            DefaultLevelInitialitation(0);
        }
    }

    //Initialize the levels from the level data
    void LoadedLevelInitialitation (List<SaveInfo> datalist)
    {
        int i = 0;
        for (; i < datalist.Count; i++)
        {
            levelList[i].set_Name(levelList[i].lvl_Prefab.name + "(Clone)");
            levelList[i].lvl_Finished = datalist[i].lvl_Finished;
            levelList[i].initialize();
            levelList[i].flies_taken = datalist[i].flies_taken;
        }
        
        if (i >= levelList.Count) return;

        //If there are levels that havent been loaded, they are initialize by default
        DefaultLevelInitialitation(i);
    }
    #endregion


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
        LoadSave();
       
    }

    #region Level Control

    //Initialize the levels to default state (Unfinished and 0 flies taken)
    void DefaultLevelInitialitation (int index)
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

        SaveData();

        Debug.Log(Application.persistentDataPath);
   
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

