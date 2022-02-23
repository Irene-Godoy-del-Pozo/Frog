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

        public bool[] flies_taken;

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
         * 1-  poner las moscas maximas como lenght de flies taken.
         * 2-  desactivar las moscas que ya hallan sido recogidas en caso de que ya nos lo hubiesemos pasado el nivel
         * 
         * Esto deberia cargarse desde player pref o de algun sitio con los datos guardados.
         */
    }


    /* Acabar nivel:
     * 1- Guardas info en el struct
     * 2- Desactivas gameobject
     * 3- Vuelves a Menu de niveles
     * 
     * */

}

