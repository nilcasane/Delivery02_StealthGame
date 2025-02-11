using UnityEngine;

public class RobotPatrol : StateMachineBehaviour
{
    private EnemyVision _enemyVision;
    private RobotController _controller;

    
    private Transform _target;
    private Rigidbody2D _rb;
    private float _timer;
    private float deviation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _enemyVision = animator.GetComponent<EnemyVision>();
        _controller = animator.GetComponent<RobotController>();
        _rb = _controller.RigidBody;
        _target = _controller.Waypoints[_controller.currentWaypoint];
        deviation = _controller.Deviation;
    }   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move
        Vector2 targetPos = _target.position;
        _rb.MovePosition(
            Vector2.MoveTowards(
                animator.transform.position,
                targetPos,
                _controller.patrolSpeed * Time.deltaTime
            )
        );

        // Rotación con Quaternion
        Vector2 direction = targetPos - (Vector2)animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _rb.MoveRotation(Quaternion.RotateTowards(animator.transform.rotation, targetRotation, 5000 * Time.deltaTime));

        // Check
        if (Vector2.Distance(animator.transform.position, targetPos) < 0.1f)
        {
            _controller.NextWaypoint();
            animator.SetBool("IsPatroling", false);
        }
        else
        {
            // Check triggers
            var playerClose = _enemyVision.IsPlayerDetected;
            var timeUp = IsTimeUp();

            animator.SetBool("IsChasing", playerClose);
            animator.SetBool("IsPatroling", !timeUp);
        }
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > _controller.patrolStayTime);
    }
}
