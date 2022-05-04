using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInfo 
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
