using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    /*TODO:   
    * ruta de patrulla
    * */

    public List<Transform> wayPoints = new List<Transform>();

    int nextPosition;

    public float speed;
  
    public bool circular; //The tramp go from the last point to the first
    
    public Transform tramp;

    bool isreturning;

    // Start is called before the first frame update
    void Start()
    {
        tramp.position = wayPoints[0].position;
        nextPosition = 1;
        isreturning = false;

        StartCoroutine("Patrol");
    }

  
    IEnumerator Patrol()
    {
        while(true)
        {
            //Move the object to the next point
            if(Vector3.Distance(tramp.position, wayPoints[nextPosition].position) > 0.01f)
                tramp.position = Vector3.MoveTowards(tramp.position, wayPoints[nextPosition].position, speed * Time.deltaTime);
            else
            {
                //Check if the next position was the last waypoint
                if(nextPosition >= wayPoints.Count-1)
                {
                    if (circular)
                        nextPosition = 0;
                    else 
                    {
                        isreturning = true;
                        nextPosition--;
                    }

                }
                else if (nextPosition <= 0 && !circular)//Check if is a returning patrol
                {                
                    isreturning = false;
                    nextPosition++;
                }
                else
                {

                    if (isreturning)
                        nextPosition--;
                    else
                    {
                       nextPosition++;
                    }
                }

            }

            yield return null;

        }
    }
}
