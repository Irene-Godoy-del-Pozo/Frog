using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flies : MonoBehaviour
{
    //TODO: DECIDIR SI SE QUIERE QUE SIGA UN CAMINO Y LAS ANMACIONES

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
