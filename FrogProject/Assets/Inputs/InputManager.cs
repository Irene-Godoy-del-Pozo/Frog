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
    }


    private void DrawTrajectory(InputAction.CallbackContext context)
    {
        player.GetComponent<ArcMovement>().StartMovement(frogactions.Play.TouchPosition.ReadValue<Vector2>(),frogactions);
    }

    private void Move(InputAction.CallbackContext context)
    {
        player.GetComponent<ArcMovement>().Move();
    }



}
