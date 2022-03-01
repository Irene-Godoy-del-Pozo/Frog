using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public GameObject player;

    FrogActions frogactions;

    private void Awake()
    {
        frogactions = new FrogActions();

   
    }
    private void OnEnable()
    {
        frogactions.Enable();
    }
    private void OnDisable()
    {
        frogactions.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
    
        frogactions.Play.Trajectory.started     += DrawTrajectory;
        frogactions.Play.Trajectory.canceled    += Move;
        frogactions.Play.Debug.performed        += Debug;
        frogactions.Play.Debug2.performed       += Debug2;
    }


    private void DrawTrajectory(InputAction.CallbackContext context)
    {
        player.GetComponent<ArcMovement>().StartMovement(frogactions.Play.TouchPosition.ReadValue<Vector2>(),frogactions);
    }

    private void Move(InputAction.CallbackContext context)
    {
        player.GetComponent<ArcMovement>().Move();
    }

    private void Debug(InputAction.CallbackContext context)
    {
        //GameManager._intance.currentLevel.LevelFinished();
        Level.OnHited();
    }
    private void Debug2(InputAction.CallbackContext context)
    {
        //GameManager._intance.currentLevel.LevelFinished();
        Level.OnHealed();
    }
}
