using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweening : MonoBehaviour
{
    public bool enablemovement;

    public Vector2 startPosition;

    public Vector2 endPosition;

    public float movement_Speed = 2f;

    public float delay_Movement=0;

    public bool enableSize;

    public Vector2 startSize;

    public Vector2 endSize;

    public float resize_Speed = 2f;

    public float delay_Size = 0;

    public bool activate_begining = false;

    public bool deactivate_ending = false;

    private void OnEnable()
    {
        if(islooping)
        {
            target_size = endSize;
            StartCoroutine("LoopResize");
        }
    }

    //Corutina variables
    public Vector2 target_movement;
    public bool isrunning_movement = false;

    public IEnumerator MoveUI()
    {
        if(!enablemovement)
        {
            Debug.LogError("Inorder to move this object, you need to enable movement on the inspector");
           
        }
        else
        {
            isrunning_movement = true;
            yield return new WaitForSeconds(delay_Movement);
        

            //Check if have to activate the gameobject
            if (activate_begining) gameObject.SetActive(true);


            while(Vector2.Distance(gameObject.GetComponent<RectTransform>().position,target_movement)>0.01)
            {
                gameObject.GetComponent<RectTransform>().position = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().position, target_movement,0.1f*  movement_Speed);
                yield return null;
            }

            if (deactivate_ending) gameObject.SetActive(false);

        }

        isrunning_movement = false;
    }

    //Corutina variables
    public Vector2 target_size;
    public bool isrunning_scale = false;

    public IEnumerator ResizeUI()
    {
        if (!enableSize)
        {
            Debug.LogError("Inorder to resize this object, you need to enable Resize on the inspector");

        }
        else
        {
            isrunning_scale = true;
            yield return new WaitForSeconds(delay_Size);


            //Check if have to activate the gameobject
            if (activate_begining) gameObject.SetActive(true);


            while (Vector2.Distance(gameObject.GetComponent<RectTransform>().sizeDelta, target_size) > 0.01)
            {
                gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().sizeDelta, target_size, 0.1f * resize_Speed);
                yield return null;
            }

            if (deactivate_ending) gameObject.SetActive(false);

            isrunning_scale = false;
        }
    }

    public bool islooping = false;
    public void StarLoopingSize()
    {
        if (islooping) return;
        islooping = true;
        target_size = endSize;
        StartCoroutine("LoopResize");
    }
    public void StopLooping()
    {
        if (!islooping) return;
        islooping = false;
        StopCoroutine("LoopResize");
    }

    IEnumerator LoopResize()
    {
        while (true)
        {
            if(Vector2.Distance(gameObject.GetComponent<RectTransform>().sizeDelta, target_size) > 0.01)
                gameObject.GetComponent<RectTransform>().sizeDelta = Vector2.MoveTowards(gameObject.GetComponent<RectTransform>().sizeDelta, target_size, 0.1f *  resize_Speed);
            else
            {
                if (target_size == startSize) target_size = endSize;
                else target_size = startSize;

            }


            yield return null;
        }

        
    }

}
