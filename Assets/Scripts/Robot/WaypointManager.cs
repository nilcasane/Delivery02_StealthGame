using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public Transform[] Waypoints;
    [SerializeField]
    public int actualWaypoint {  get; private set; }
    
    private void Start()
    {
        actualWaypoint = 0;
    }
    void Update()
    {
        
    }
    public Transform ActualWaypoint()
    {
        return Waypoints[actualWaypoint];
    }
    public void IncreaseWaypoint()
    {
        actualWaypoint++;
    }
}
