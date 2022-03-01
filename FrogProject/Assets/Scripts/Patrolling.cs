using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    /*TODO:   
    * ruta de patrulla
    * poder pausar la ruta de patrulla en pausa
    * 
    * 
    * */

    public List<Transform> wayPoints = new List<Transform>();

    int nextPosition;

    public float speed;

    
    public bool circular;
    
    //public bool canReturn;

    public Transform trap;

    bool isreturning;

    // Start is called before the first frame update
    void Start()
    {
        trap.position = wayPoints[0].position;
        nextPosition = 1;
        isreturning = false;

        StartCoroutine("Patrol");
    }

  
    IEnumerator Patrol()
    {
        while(true)
        {
            if(Vector3.Distance(trap.position, wayPoints[nextPosition].position) > 0.01f)
                trap.position = Vector3.MoveTowards(trap.position, wayPoints[nextPosition].position, speed * Time.deltaTime);
            else
            {
                Debug.Log("Ha llegado");
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
                else if (nextPosition <= 0 && !circular)//Aqui solo entraremos si estamos returneando
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
                        Debug.Log(" ++");
                        nextPosition++;
                    }
                }

            }

            Debug.Log(nextPosition);

            yield return null;

        }
    }
}
