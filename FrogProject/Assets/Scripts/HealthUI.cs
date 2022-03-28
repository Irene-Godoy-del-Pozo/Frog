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
        float heartWidth = heartPrefab.GetComponent<RectTransform>().rect.width;

        //Create the maximum hearts
        for (int i = 0; i < GameManager._intance.GetMaxHealth(); i++)
        {
            heartList.Add(Instantiate(heartPrefab,transform));

            heartList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(heartWidth / 2 + (i * (heartWidth + 10)), 0 );
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
        //Dead function
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
