using UnityEngine;

public class RobotPatrol : StateMachineBehaviour
{
    private EnemyVision _enemyVision;
    private RobotController _controller;

    
    private Transform _target;
    private Rigidbody2D _rb;
    private float _timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _enemyVision = animator.GetComponent<EnemyVision>();
        _controller = animator.GetComponent<RobotController>();
        _rb = _controller.RigidBody;
        _target = _controller.Waypoints[_controller.currentWaypoint];
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
        /*Quaternion targetRotation = Quaternion.LookRotation(targetPos);
        Quaternion rotation = Quaternion.RotateTowards(animator.transform.rotation, targetRotation, 5 * Time.deltaTime);
        _rb.MoveRotation(rotation);*/

        _rb.rotation = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;

        //Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg

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
