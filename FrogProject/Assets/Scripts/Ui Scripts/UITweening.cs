using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweening : MonoBehaviour
{
    public bool enablemovement;

    public Vector2 startPosition;

    public Vector2 endPosition;

    public float time_Movement = 5;

    public float delay_Movement=0;

    public bool enableSize;

    public Vector2 startSize;

    public Vector2 endSize;

    public float time_Size = 1;

    public float delay_Size = 0;

    public bool activate_begining;

    public bool deactivate_ending;



    //Corutina variables
    public Vector2 target_movement;
    public bool isrunning= false;

    public IEnumerator MoveUI()
    {
        isrunning = true;
        yield return new WaitForSeconds(delay_Movement);
        

        //Check if have to activate the gameobject
        if (activate_begining) gameObject.SetActive(true);


        while(Vector2.Distance(gameObject.GetComponent<RectTransform>().position,target_movement)>0.01)
        {
            gameObject.GetComponent<RectTransform>().position = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().position, target_movement, time_Movement);
            yield return null;
        }

        if (deactivate_ending) gameObject.SetActive(false);

        isrunning = false;
    }

 
}
