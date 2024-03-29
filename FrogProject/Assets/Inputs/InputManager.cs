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
        
        frogactions.Play.Trajectory.started += DrawTrajectory;
        frogactions.Play.Trajectory.canceled += Move;
        frogactions.Play.Debug.performed += _Debug;
        frogactions.Play.Debug2.performed += _Debug2;
    }


    private void DrawTrajectory(InputAction.CallbackContext context)
    {
        if (!IsUI() && GameManager._intance.gamePaused == false)
            player.GetComponent<ArcMovement>().StartTrajectoryPrediction(frogactions.Play.TouchPosition.ReadValue<Vector2>(), frogactions);
        else
            Debug.Log("UI");
    }

    private void Move(InputAction.CallbackContext context)
    {
        player.GetComponent<ArcMovement>().Move();
    }

    //Debug function 1
    private void _Debug(InputAction.CallbackContext context)
    {
        GameManager._intance.currentLevel.LevelFinished();
    }
    //Debug function 2
    private void _Debug2(InputAction.CallbackContext context)
    {
        Level.OnHealed();
    }

    //Checks if the touch of the screen es valid or is the UI
    bool IsUI()
    {
        return frogactions.Play.TouchPosition.ReadValue<Vector2>().y > (Camera.main.scaledPixelHeight - 100);
    }
}
