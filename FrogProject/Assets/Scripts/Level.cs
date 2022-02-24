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
    Vector3 strart_Position;

    public List<Flies> flies = new List<Flies>();


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
