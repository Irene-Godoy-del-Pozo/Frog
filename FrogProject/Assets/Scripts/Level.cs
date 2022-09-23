using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    [SerializeField]
    public Transform start_Position;

    public List<Flies> flies = new List<Flies>();       //Flies of the level

    public List<Healer> healers = new List<Healer>();   //Heal Objects of the level

    public GameObject scoreTab;

    GameObject player;

    public void SetPlayer(GameObject _player) 
    {
        player = _player; 
        player.GetComponent<ArcMovement>().respawnPosition = start_Position.position;
        player.GetComponent<Health>().RestartHealth();
    }

    public HealthUI healthUI;   //Health HUD

    
    public delegate void HealthAction();

    public static HealthAction OnHited; 
    public static HealthAction OnHealed;

    private void Start()
    {
        
        healthUI.LevelStarted();
        player.SetActive(true);
        foreach (Healer healer in healers)
        {
            healer.gameObject.SetActive(true);
        }
        scoreTab.gameObject.SetActive(false);
    }

    public void LevelFinished ()
    {
        GameManager._intance.PauseGame(true);
        scoreTab.gameObject.SetActive(true);
        /*  
         *  sale el prefab de puntuaciones 
         *      -(tendra un boton de salir)
         *      -animacion de las moscas que se han recogido
        */
        GameManager._intance.LevelFinished(this);
    }


}
