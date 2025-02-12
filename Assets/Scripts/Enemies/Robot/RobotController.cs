using System;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] Waypoints;
    public int CurrentWaypoint {  get; private set; }
    private bool _ascendingWaypoints = true;

    [Header("Settings")]
    public float PatrolSpeed = 10f;
    public float PatrolStayTime = 6f;
    public float ChaseSpeed = 4f;
    public float DetectionRadius = 5f;
    public float IdleDuration = 1f;

    public Transform Player;
    public Rigidbody2D RigidBody;

    public static Action OnCameraWarning;

    private void Start()
    {
        CurrentWaypoint = 0;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RigidBody = GetComponent<Rigidbody2D>();
    }

    public void NextWaypoint()
    {
        if(_ascendingWaypoints)
        {
            if(CurrentWaypoint == Waypoints.Length-1)
            {
                _ascendingWaypoints = false;
                CurrentWaypoint--;
            }
            else
            {
                CurrentWaypoint++;
            }
        }
        else
        {
            if (CurrentWaypoint == 0)
            {
                _ascendingWaypoints = true;
                CurrentWaypoint++;
            }
            else
            {
                CurrentWaypoint--;
            }
        }
    }
}
