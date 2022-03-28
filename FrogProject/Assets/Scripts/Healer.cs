using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{

    public int healQuantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            for (int i = 0; i < healQuantity; i++)
            {
                Level.OnHealed();
            }

            this.gameObject.SetActive(false);
        }
    }
   
}
