using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject heartPrefab;

    List<GameObject> heartList = new List<GameObject>();

    int currentHearts;

    public void LevelStarted()
    {
        for (int i = 0; i < GameManager._intance.GetMaxHealth(); i++)
        {
            heartList.Add(Instantiate(heartPrefab, this.gameObject.transform));
        }

        currentHearts = GameManager._intance.GetMaxHealth();
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


    void Damaged()
    {
        if(currentHearts>0)
        {
            heartList[currentHearts - 1].SetActive(false);
            currentHearts--;
        }
    }

    void Healed()
    {
        if (currentHearts < GameManager._intance.GetMaxHealth())
        {
            heartList[currentHearts].SetActive(true);
            currentHearts++;
        }
    }


}
