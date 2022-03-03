using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //[SerializeField]
    //int maxFlies;

    //public int GetMaxFlies() { return maxFlies; }

    //int fliesTaken = 0;

    //bool finished = false;

    [SerializeField]
    public Transform start_Position;

    public List<Flies> flies = new List<Flies>();

    public List<Healer> healers = new List<Healer>();

    GameObject player;
    public void SetPlayer(GameObject _player) { player = _player; }

    public HealthUI healthUI;

    public delegate void HealthAction();

    public static HealthAction OnHited;
    public static HealthAction OnHealed;

    private void Start()
    {
        player.GetComponent<ArcMovement>().respawnPosition = start_Position.position;
        healthUI.LevelStarted();

        foreach (Healer healer in healers)
        {
            healer.gameObject.SetActive(true);
        }
    }

    public void LevelFinished ()
    {
        Debug.Log("Ha llegado al level");
        GameManager._intance.LevelFinished(this);
    }

    










}
