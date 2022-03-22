using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //public InputManager inputManager;
    public static GameManager _intance { get; private set; }
   


   
    [SerializeField]
    private int maxHealth;

    public int GetMaxHealth() { return maxHealth; }

    public Level currentLevel;

    public GameObject playerPref;

    public InputManager inputManager;

    public GameObject mainMenu;

    public GameObject pauseMenu;

    public GameObject levelMenu;



    [Serializable]
    private class LevelInfo
    {
        
        public GameObject lvl_Prefab;

        public bool lvl_Finished;

        public string lvl_Name; // TODO: hacer privada

        public string get_Name() { return lvl_Name; }
        public void set_Name(string newName) { lvl_Name = newName; }

        public bool[] flies_taken; // TODO: hacer privada

        public bool[] getFlies() { return flies_taken; }
        public void setFlies(int index, bool state) { flies_taken[index] = state; }
        public void initialize() { flies_taken = new bool[3]; }
    }
    
    [SerializeField]
    List<LevelInfo> levelList = new List<LevelInfo>();

    #region Save Data

    [Serializable]
    public class SaveInfo
    {
        public string lvl_Name;

        public bool lvl_Finished;

        public bool[] flies_taken;
    }

    [Serializable]
    public class SaveInfoList
    {
        public List<SaveInfo> savedataList;
    }
    public void SaveData()
    {
        SaveInfoList datalist = new SaveInfoList();
        datalist.savedataList = new List<SaveInfo>();
        foreach (LevelInfo _levelinfo in levelList)
        {
            //The levels can only be finished in order. If this level isnt finished, the function can stop searching.
            if (!_levelinfo.lvl_Finished) return;

            SaveInfo data = new SaveInfo();

            data.lvl_Name = _levelinfo.get_Name();
            data.lvl_Finished = _levelinfo.lvl_Finished;
            data.flies_taken = new bool[_levelinfo.flies_taken.Length];
            data.flies_taken = _levelinfo.flies_taken;
            
            datalist.savedataList.Add(data);
           

        }

       
        if (datalist.savedataList.Count !=0)
        {
            string path = Path.Combine(Application.persistentDataPath, "save"+currentsave+".json");
            //if(curren)
            Debug.Log(JsonUtility.ToJson(datalist));
           
            File.WriteAllText(path, JsonUtility.ToJson(datalist, true));
        }
    }
    /*
    1- Si no hay archivo, creamos uno (desde el numero 0)
    2- Averiguamos cual es el ultimo archivo que se modifico
    3- Averiguamos que numero corresponde y lo añadimos a current level


    */
    int maxSaves = 6;
    int currentsave = 0;


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


        LevelInitialitation();

       
    }
    
    void LevelInitialitation ()
    {
        
        foreach (LevelInfo _levelinfo in levelList)
        {
            //Add Clone to the name for easiest comparations in the future
            _levelinfo.set_Name(_levelinfo.lvl_Prefab.name + "(Clone)");

            Level a = _levelinfo.lvl_Prefab.GetComponent<Level>();

            _levelinfo.initialize();
            //TODO: CARGAR DEL ARCHIVO DE GUARDADO LAS FLIES TAKEN Y TODOS LOS DATOS DE CADA NIVEL GUARDADOS

            ////Only check the flies taken if the player has completed the level
            //if (_levelinfo.lvl_Finished)
            //{
            //    //Level level = _levelinfo.lvl_Prefab.GetComponent<Level>();

            //    //Activate/Deactivate flie's gameObjects 
            //    ActivateFlies(_levelinfo);//_levelinfo.getFlies(),level.flies);

            //}



        }
      
    }

  


    /* Acabar nivel:
     * 1- DONE Guardas info en el struct
     * * 1-  DONE poner las moscas maximas como lenght de flies taken. ESTO SE HACE AL TERMINAR NIVEL
     * 
     * 2- Desactivas gameobject
     * 3- Vuelves a Menu de niveles
     * 
     * */

    public void LevelFinished(Level level)
    {
        Debug.Log("Ha llegado al GM");
        //Update info saved in the level info 
        foreach (LevelInfo _levelinfo in levelList)
        {
            if (string.Equals(_levelinfo.get_Name(), level.gameObject.name))
            {
                _levelinfo.lvl_Finished = true;

                for (int i = 0; i < level.flies.Count; i++)
                {
                    _levelinfo.setFlies(i, !level.flies[i].gameObject.activeSelf);
                  
                }

                level.gameObject.SetActive(false);

                LevelsMenu();

                

                break;


            }
            Debug.Log("a");
        }

        SaveData();

        Debug.Log(Application.persistentDataPath);
   
    }


    public void StartLevel(int index)
    {

        levelMenu.SetActive(false);

        ActivateFlies(levelList[index], levelList[index].lvl_Finished);

        inputManager.player = Instantiate(playerPref);// ,levelList[index].lvl_Prefab.GetComponent<Level>().start_Position.position, playerPref.transform.rotation);
        GameObject level = Instantiate(levelList[index].lvl_Prefab);

        

        currentLevel = level.GetComponent<Level>();

        currentLevel.SetPlayer(inputManager.player);

        inputManager.gameObject.SetActive(true);



    }

    //Activate or Deactivate flies gameobject given the level info 
    private void ActivateFlies(LevelInfo levelInfo, bool isPassed) //List<bool> fliestaken , List<Flies> levelflies)
    {
        Level level = levelInfo.lvl_Prefab.GetComponent<Level>();
        //Set Active according to information stored in level info
        if(isPassed)
        {
            for (int i = 0; i < levelInfo.getFlies().Length; i++)
            {
                level.flies[i].gameObject.SetActive(levelInfo.getFlies()[i]);
            }
        }
        //Set active true 
        else
        {
            for (int i = 0; i < level.flies.Count; i++)
            {
                level.flies[i].gameObject.SetActive(true);
            }
        }
    }


    public bool[] GetFliesOfLevels(int level)
    {
        if (!levelList[level].lvl_Finished) return new bool[] { false, false, false };
        return levelList[level].getFlies();//.ToArray();
    }


    public void LevelsMenu()
    {
        
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        pauseMenu.SetActive(true);
        inputManager.gameObject.SetActive(false);
   
    }

    public bool gamePaused = false;
    public void PauseGame(bool isPaused)
    {
        gamePaused = isPaused;
        if (isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }



}

