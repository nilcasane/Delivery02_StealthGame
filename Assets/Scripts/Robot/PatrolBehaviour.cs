using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolBehaviour : StateMachineBehaviour
{
    public float Speed = 2f;
    public float StayTime = 2f;

    private float _timer;
    private Transform _player;
    private Vector2 _target;
    private Vector2 _startPos;

    private EnemyVision _enemyVision;


    WaypointManager _waypointManager;
    public int CurrentWaypointIndex = 0;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyVision = animator.GetComponent<EnemyVision>();
        _waypointManager = animator.GetComponent<WaypointManager>();
        _startPos = new Vector2(animator.transform.position.x, animator.transform.position.y);
        _target = _waypointManager.ActualWaypoint().position;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check triggers
        var playerClose = _enemyVision.IsPlayerDetected;
        var timeUp = IsTimeUp();
        
        animator.SetBool("IsChasing", playerClose);
        animator.SetBool("IsChasing", !timeUp);

        // Move
        _target = _waypointManager.ActualWaypoint().position;
        if (Vector2.Distance(animator.transform.position, _target) < 0.1f)
        {
            _waypointManager.IncreaseWaypoint();
        }
        else
        {
            animator.transform.position = Vector2.MoveTowards(_startPos, _target, Speed * Time.deltaTime);
        }
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > StayTime);
    }
}
