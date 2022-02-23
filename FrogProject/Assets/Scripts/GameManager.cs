using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //public InputManager inputManager;
    public static GameManager _intance { get; private set; }

    private void Awake()
    {
        if (_intance != null && _intance != this)
        {
            Destroy(this);
            return;
        }
        _intance = this;

        DontDestroyOnLoad(transform.gameObject);
    }
   
    public int maxHealth;

    public int fliesPerLevel;







}
