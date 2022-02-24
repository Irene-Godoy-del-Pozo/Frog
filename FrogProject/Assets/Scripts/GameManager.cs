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

    //[SerializeField]
    //private int fliesPerLevel;

    //public int GetFliesPerLevel() { return fliesPerLevel; }

 
    [System.Serializable]
    public struct LevelInfo
    {
        public GameObject lvl_Prefab;

        public bool lvl_Finished;

        List<bool> flies_taken;

        public List<bool> getFlies() { return flies_taken; }
       // public bool[] setFlies(int a) { return flies_taken = new bool[a]; }
    }
    
    
    public List<LevelInfo> levelList = new List<LevelInfo>();


    private void Awake()
    {
        if (_intance != null && _intance != this)
        {
            Destroy(this);
            return;
        }
        _intance = this;

        DontDestroyOnLoad(transform.gameObject);

        /*TODO: Acceder al script level de cada gameobject y->
         
         * 2-  desactivar las moscas que ya hallan sido recogidas en caso de que ya nos lo hubiesemos pasado el nivel
         * 
         * Esto deberia cargarse desde player pref o de algun sitio con los datos guardados.
         */

        LevelInitialitation();

        Debug.Log("Moscas: "+levelList[0].getFlies().Count);
    }

    void LevelInitialitation ()
    {
        foreach(LevelInfo _levelinfo in levelList)
        {

            if (!_levelinfo.lvl_Finished) return;

            Level level = _levelinfo.lvl_Prefab.GetComponent<Level>();

            //Activate/Deactivate flie's gameObjects 
            FliesInLevel(_levelinfo.getFlies(),level.flies);

           
        }
    }

    //Activate or Deactivate flies gameobject given the bool[] 
    private void FliesInLevel(List<bool> fliestaken , List<Flies> levelflies)
    {        
        for (int i = 0; i < fliestaken.Count; i++)
        {
            levelflies[i].gameObject.SetActive(fliestaken[i]);            
        }
    }

    /* Acabar nivel:
     * 1- Guardas info en el struct
     * * 1-  poner las moscas maximas como lenght de flies taken. ESTO SE HACE AL TERMINAR NIVEL
     * 2- Desactivas gameobject
     * 3- Vuelves a Menu de niveles
     * 
     * */

}

