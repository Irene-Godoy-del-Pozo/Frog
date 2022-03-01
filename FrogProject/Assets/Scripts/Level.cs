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

    GameObject player;
    public void SetPlayer(GameObject _player) { player = _player; }

    public HealthUI healthUI;

    public delegate void Action();
    public static Action OnHited;
    public static Action OnHealed;

    private void Start()
    {
        player.transform.position = start_Position.position;
        healthUI.LevelStarted();
    }

    public void LevelFinished ()
    {
        Debug.Log("Ha llegado al level");
        GameManager._intance.LevelFinished(this);
    }

    










}
