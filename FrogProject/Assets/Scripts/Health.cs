using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

  
    int maxHealth = 5;

    int currentHealth;

    private void Start()
    {
        maxHealth = GameManager._intance.GetMaxHealth();
        RestartHealth();
      
    }

    private void OnEnable()
    {
        Level.OnHited += Damaged;

        Level.OnHealed += Healed;
    }
    private void OnDisable()
    {
        Level.OnHited -= Damaged;

        Level.OnHealed -= Healed;
    }

    void RestartHealth()
    {
        currentHealth = GameManager._intance.GetMaxHealth();
        Debug.Log("HealthMax: " + currentHealth);
    }

    void Damaged()
    {
       
        currentHealth = Mathf.Clamp(currentHealth--, 0, maxHealth);

        
        if (currentHealth == 0)
            Dead();


        //Animacion de daño o muerte si corresponde

      
    }

    void Healed()
    {
        currentHealth = Mathf.Clamp(currentHealth++, 0, maxHealth);
  
    }

    void Dead()
    {
        //TODO:
        //Animacion muerte?
        //Desactivar gameobject
        //UI has muerto

    }

    



}
