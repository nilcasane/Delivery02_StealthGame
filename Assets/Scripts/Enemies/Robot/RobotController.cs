using System;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] Waypoints;
    [SerializeField]
    public int currentWaypoint = 0;
    [SerializeField]
    private bool ascendingWaypoints = true;


    [Header("Settings")]
    public float patrolSpeed = 10f;
    public float patrolStayTime = 6f;
    public float chaseSpeed = 4f;
    public float detectionRadius = 5f;
    public float idleDuration = 1f;

    public Transform player;
    public Rigidbody2D RigidBody;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RigidBody = GetComponent<Rigidbody2D>();
    }
    public void NextWaypoint()
    {
        if(ascendingWaypoints)
        {
            if(currentWaypoint == Waypoints.Length-1)
            {
                ascendingWaypoints = false;
                currentWaypoint--;
            }
            else
            {
                currentWaypoint++;
            }
        }
        else
        {
            if (currentWaypoint == 0)
            {
                ascendingWaypoints = true;
                currentWaypoint++;
            }
            else
            {
                currentWaypoint--;
            }
        }
    }
}
