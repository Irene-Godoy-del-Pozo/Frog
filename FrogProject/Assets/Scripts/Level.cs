using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    int maxFlies;
    int fliesTaken = 0;

    bool finished = false;


    // Start is called before the first frame update
    void Start()
    {

        maxFlies = GameManager._intance.fliesPerLevel;

        if (finished == false)
            fliesTaken = 0;
        //TODO: else (hay que guardar quiza con struct)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
