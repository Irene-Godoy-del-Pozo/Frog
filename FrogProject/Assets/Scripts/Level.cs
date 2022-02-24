using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    int maxFlies;

    public int GetMaxFlies() { return maxFlies; }

    //int fliesTaken = 0;

    //bool finished = false;

    [SerializeField]
    public Transform strart_Position;

    public List<Flies> flies = new List<Flies>();



    public void LevelFinished ()
    {
        Debug.Log("Ha llegado al level");
        GameManager._intance.LevelFinished(this);
    }












}
