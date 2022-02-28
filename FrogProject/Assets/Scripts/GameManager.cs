using System;
using System.Collections;
using System.Collections.Generic;
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

    [System.Serializable]
    private class LevelInfo
    {
        public GameObject lvl_Prefab;

        public bool lvl_Finished;

        public string lvl_Name; // TODO: hacer privada

        public string get_Name() { return lvl_Name; }
        public void set_Name(string newName) { lvl_Name = newName; }

        public List<bool> flies_taken; // TODO: hacer privada

        public List<bool> getFlies() { return flies_taken; }
        public void setFlies(int index, bool state) { flies_taken[index] = state; }
    }
    
    [SerializeField]
    List<LevelInfo> levelList = new List<LevelInfo>();


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

        StartLevel(0);//TEMPORAL
    }
    
    void LevelInitialitation ()
    {
        
        foreach (LevelInfo _levelinfo in levelList)
        {
            //Add Clone to the name for easiest comparations in the future
            _levelinfo.set_Name(_levelinfo.lvl_Prefab.name + "(Clone)");

            Level a = _levelinfo.lvl_Prefab.GetComponent<Level>();
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
                    _levelinfo.setFlies(i, level.flies[i].gameObject.activeSelf);
                  
                }
                
                

            }
        }
        Debug.Log("Ha llegado al final GM");
    }


    void StartLevel(int index)
    {
        
        ActivateFlies(levelList[index], levelList[index].lvl_Finished);

        GameObject a = Instantiate(levelList[index].lvl_Prefab);

        

        currentLevel = a.GetComponent<Level>();

        inputManager.player = Instantiate(playerPref, levelList[index].lvl_Prefab.GetComponent<Level>().strart_Position.position, playerPref.transform.rotation);
    }

    //Activate or Deactivate flies gameobject given the level info 
    private void ActivateFlies(LevelInfo levelInfo, bool isPassed) //List<bool> fliestaken , List<Flies> levelflies)
    {
        Level level = levelInfo.lvl_Prefab.GetComponent<Level>();
        //Set Active according to information stored in level info
        if(isPassed)
        {
            for (int i = 0; i < levelInfo.getFlies().Count; i++)
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









}

