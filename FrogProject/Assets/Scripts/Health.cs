using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    //TODO: Asignar desde Gamemanager
    int maxHealth = 5;

    int currentHealth;

    private void Start()
    {
        RestartHealth();
        //TODO: Decidir si se conserva vida entre escenas
    }

    void RestartHealth()
    {
        currentHealth = maxHealth;
    }

    void Damaged()
    {
        currentHealth = Mathf.Clamp(currentHealth--, 0, maxHealth);
        //TODO: Update UI
        if (currentHealth == 0)
            Dead();
    }

    void Healed()
    {
        currentHealth = Mathf.Clamp(currentHealth++, 0, maxHealth);
        //TODO: Update UI
    }

    void Dead()
    {
        //TODO:
        //Animacion muerte?
        //Desactivar gameobject
        //UI has muerto

    }

    



}
