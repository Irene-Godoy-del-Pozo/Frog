using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArcMovement : MonoBehaviour
{

    private LineRenderer line_renderer;
    List<Vector3> points = new List<Vector3>(); //Point to follow and to draw the linear render
    Camera camera;
    Rigidbody2D rb;

  
    public float mass;
    public float velosityboost;
    public float timeStep = 0.1f;
    public float maxDuration;
 
    Coroutine coroutine;

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
        line_renderer = GetComponent<LineRenderer>();
        ClearLinerendere(points.Count);//((int)(maxDuration / timeStep));
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        
        frogactions.Play.Trajectory.started += Test;
        frogactions.Play.Trajectory.canceled += Test2;
    }

    Vector2 startTouchPosition;
    private void Test(InputAction.CallbackContext context)
    {


        startTouchPosition = camera.ScreenToWorldPoint(frogactions.Play.TouchPosition.ReadValue<Vector2>());

        coroutine = StartCoroutine("LineTrajectory");
    }

    float velocityrb = 0;
    Vector3 direction;
    public int maxHeight;
    public int minHeight;
    public float maxAngle;
    public float minAngle;
    public float rad_angle;

    IEnumerator LineTrajectory()
    {
        
        while(true)
        {
            Vector2 endTouchPosition = camera.ScreenToWorldPoint(frogactions.Play.TouchPosition.ReadValue<Vector2>());

            direction = endTouchPosition - startTouchPosition ;

          

            direction = -direction;//Invert the direction

            if (direction.y < 0) direction.y = 0;



            float vel_magnitude = direction.magnitude;
            if (vel_magnitude < minHeight) vel_magnitude = minHeight;
            if (vel_magnitude > maxHeight) vel_magnitude = maxHeight;



            Vector2 point_base = new Vector2(startTouchPosition.x + 100, startTouchPosition.y);
            Vector3 vecbase = point_base - startTouchPosition;
               
            float angle = Vector3.Angle(vecbase, direction);


            //Clamp the angle between the range given
            if (angle <= minAngle)
            {
                angle = minAngle;
                rad_angle = minAngle * Mathf.PI / 180;
                direction.x = Mathf.Cos(rad_angle) * vel_magnitude;
                direction.y = Mathf.Sin(rad_angle) * vel_magnitude;
        
            }

            else if (angle >= maxAngle)
            {
                angle = maxAngle;
                rad_angle = maxAngle * Mathf.PI / 180;
                direction.x = Mathf.Cos(rad_angle) * vel_magnitude;
                direction.y = Mathf.Sin(rad_angle) * vel_magnitude;
            }
            else
                rad_angle = angle * Mathf.PI / 180;

         
            direction = direction.normalized; // vector normalized


            velocityrb = vel_magnitude ;
          
            ParabolicTrajectoryPoints(velocityrb, direction);
            DrawParabolic();
           

            yield return null;
        }
    }

    /// <summary>
    /// Points of a parabolic trajectory given a force and a direction
    /// </summary>
    /// <param name="velocity"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public void ParabolicTrajectoryPoints(float velocity , Vector3 direction)
    {
        points.Clear();
       

       // points.Add(transform.position + direction);

        for (int i = 0; i < (int)(maxDuration / timeStep); i++)
        {

            Vector3 next_position = transform.position +
                                    new Vector3(direction.x * velocity, direction.y * velocity,0) * i * timeStep ;

            next_position.y += 0.5f * Physics2D.gravity.y * i * timeStep * i * timeStep;
         

            //Metodo con lineRaycast
            if (i>1 )
            {
                RaycastHit2D hit = Physics2D.Linecast(points[i - 1], next_position, 1 << LayerMask.NameToLayer("Collide Raycast"));
                if(hit)
                {
                    points.Add(hit.point);
                    break;
                }
            }
            


            points.Add(next_position);
        }
     
    }



    private void Test2(InputAction.CallbackContext obj)
    {
        ClearLinerendere((int)(maxDuration / timeStep));

        StopCoroutine(coroutine);



        rb.velocity = new Vector2(direction.x * velocityrb, direction.y * velocityrb);

    }

 



    private void ClearLinerendere(int totalpositions)
    {
        line_renderer.positionCount = 0;
        line_renderer.positionCount = totalpositions;
    }

    /// <summary>
    /// Draws a lines through the given points with Line Render.
    /// </summary>
    /// <param name="points"></param>
    private void DrawParabolic()
    {
        ClearLinerendere(points.Count);
       // line_renderer.positionCount = points.Count;
        line_renderer.SetPosition(0, transform.position + direction);
        for (int i = 1; i < points.Count; i++)
        {
            line_renderer.SetPosition(i, points[i]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        rb.velocity = new Vector2 (0,0);
        Debug.Log("PARADO");
    }
}
