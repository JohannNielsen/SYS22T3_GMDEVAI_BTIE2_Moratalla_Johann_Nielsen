using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraveltoGoal : MonoBehaviour
{
    public Transform goal;
    public float acceleration = 3f;
    public float deceleration = 3f;
    public float maxSpeed = 5f;
    
    private float currentSpeed = 0f;

    private void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - transform.position;

        transform.rotation = Quaternion.LookRotation(direction);

        float distanceToGoal = Vector3.Distance(transform.position, lookAtGoal);

        // Calculate target speed based on the distance to the goal
        float targetSpeed = Mathf.Clamp(distanceToGoal, 0f, maxSpeed);

        // Smoothly adjust the current speed using Lerp
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * acceleration);

        // Move the object forward based on the current speed
        if (Vector3.Distance(lookAtGoal, transform.position) > 1)
        {
            transform.Translate(0f, 0f, currentSpeed * Time.deltaTime);
        }
            
    }
}