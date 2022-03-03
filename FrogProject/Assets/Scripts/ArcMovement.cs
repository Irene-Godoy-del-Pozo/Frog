using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArcMovement : MonoBehaviour
{

    private LineRenderer line_renderer;
    List<Vector3> points = new List<Vector3>(); //List of points to draw the linear render
   
    Rigidbody2D rb;
    IEnumerator lineTrajectory; // Corutine to draw the trajectory

  
    [Header("Parabola setting")]
    public float    vel_multiplier      = 1     ;   //Multiplier to increase the intial velocity
    public float    timeStep            = 0.1f  ;   //Time passed between points
    public int      defaultPointsCount  = 50    ;   //Inital count of trajectory's points

    [Header("Limits configuration")]
    public int      maxHeight           = 10    ;   //Max height of the parabola 
    public int      minHeight           = 5     ;   //Min height of the parabola

    [Space(10)]
    public float    maxAngle            = 135   ;   //Max angle  of the initial direction
    public float    minAngle            = 45    ;   //Min angle  of the initial direction
    float           initial_velocity    = 0     ;   //Initial velocity

    float           rad_angle;                      //Angle in radians
    Vector2         startTouchPosition;             
    Vector3         direction;

    public bool isGrounded;

    public Vector3 respawnPosition;

    void Start()
    {

        line_renderer = GetComponent<LineRenderer>();

        rb = GetComponent<Rigidbody2D>();

        //Reset the Line Renderer's points count
        ClearLinerendere(points.Count);
        isGrounded = true;

        //respawnPosition = transform.position;

        Respawn();
    }

    //Start the trajectory prediction
    public void StartMovement(Vector2 start , FrogActions frogInput)
    {
        if (!isGrounded) return;

        startTouchPosition = Camera.main.ScreenToWorldPoint(start);

        lineTrajectory = LineTrajectory(frogInput);

        StartCoroutine(lineTrajectory);
    }

 
    //Start the movement
    public void Move()
    {
        //Cant move in air
        if (!isGrounded || startTouchPosition == Vector2.zero) return; 

        ClearLinerendere(defaultPointsCount);

        StopCoroutine(lineTrajectory);

        rb.velocity = new Vector2(direction.x * initial_velocity, direction.y * initial_velocity);

        startTouchPosition = Vector2.zero;
        isGrounded = false;
       
    }


    #region Trajectory prediction Functions

    /// <summary>
    /// Courutine to predict and draw the trajectory
    /// </summary>
    /// <param name="input"> ActionMap variable</param>
    /// <returns></returns>
    IEnumerator LineTrajectory(FrogActions input)
    {
        while(true)
        {
            //Get the direction vector from de first click to the actual position of the mouse/finger
            Vector2 endTouchPosition = Camera.main.ScreenToWorldPoint(input.Play.TouchPosition.ReadValue<Vector2>());

            direction = endTouchPosition - startTouchPosition ;

            //Invert the vector to achive the invert control 
            direction = -direction;


            #region Limit cases 

            // y axis cant be below 0
            if (direction.y < 0) direction.y = 0;


            float vel_magnitude = direction.magnitude;

            if (vel_magnitude < minHeight) vel_magnitude = minHeight;
            if (vel_magnitude > maxHeight) vel_magnitude = maxHeight;

            //Get the horizontal vector as base to find out the angle   
            Vector2 point_base = new Vector2(startTouchPosition.x + 100, startTouchPosition.y);
            Vector3 vecbase = point_base - startTouchPosition;
            
            //Angle in degrees 
            float angle = Vector3.Angle(vecbase, direction);


            //Clamp the angle between the range given
            if (angle <= minAngle)
            {
                angle = minAngle;
                rad_angle = DegreesToRadians( minAngle );

                direction.x = Mathf.Cos(rad_angle) * vel_magnitude;
                direction.y = Mathf.Sin(rad_angle) * vel_magnitude;
        
            }

            else if (angle >= maxAngle)
            {
                angle = maxAngle;
                rad_angle = DegreesToRadians( maxAngle );

                direction.x = Mathf.Cos(rad_angle) * vel_magnitude;
                direction.y = Mathf.Sin(rad_angle) * vel_magnitude;
            }
            else
                rad_angle = DegreesToRadians( angle );

            #endregion


            direction = direction.normalized; // direction vector normalized


            initial_velocity = vel_magnitude * vel_multiplier / rb.mass;
          
            ParabolicTrajectoryPoints(initial_velocity, direction);
                      
            yield return null;
        }
    }

    /// <summary>
    /// Points of a parabolic trajectory given a force and a direction
    /// </summary>
    /// <param name="velocity"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    private void ParabolicTrajectoryPoints(float velocity , Vector3 direction)
    {

        points.Clear();
       

        for (int i = 0; i < defaultPointsCount; i++)
        {
            // x = x0 + v0*y   y = y0 + v0*t - (g*t^2)/2 
            Vector3 next_position = transform.position + direction * velocity * i * timeStep ;

            next_position.y += 0.5f * Physics2D.gravity.y * i * timeStep * i * timeStep;
         

            //Check for collisions
            if (i > 1 )
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
        DrawParabolic();
    }



    /// <summary>
    /// Draws a lines through the given points with Line Render.
    /// </summary>
    /// <param name="points"></param>
    private void DrawParabolic()
    {
        ClearLinerendere(points.Count);
       
        line_renderer.SetPosition(0, transform.position + direction);

        for (int i = 1; i < points.Count; i++)
        {
            line_renderer.SetPosition(i, points[i]);
        }
    }

    #endregion


    private void ClearLinerendere(int totalpositions)
    {
        line_renderer.positionCount = 0;
        line_renderer.positionCount = totalpositions;
    }
    private float DegreesToRadians(float degree_angle)
    {
        return degree_angle * Mathf.PI / 180;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {    
        if(collision.gameObject.tag.Equals("Floor"))
        {
            rb.velocity = new Vector2 (0,0);
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Respawn"))
        {
            respawnPosition = collision.gameObject.transform.position;

        }
    }

    public void Respawn()
    {
        transform.position = respawnPosition;

        isGrounded = true;
    }
}
