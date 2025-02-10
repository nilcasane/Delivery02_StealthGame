using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolBehaviour : StateMachineBehaviour
{
    private EnemyVision _enemyVision;
    private EnemyController _enemyController;

    
    private Transform _target;
    private Rigidbody2D _rb;
    private float _timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _enemyVision = animator.GetComponent<EnemyVision>();
        _enemyController = animator.GetComponent<EnemyController>();
        _rb = _enemyController.RigidBody;
        _target = _enemyController.Waypoints[_enemyController.currentWaypoint];
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move
        Vector2 targetPos = _target.position;
        _rb.MovePosition(
            Vector2.MoveTowards(
                animator.transform.position,
                targetPos,
                _enemyController.patrolSpeed * Time.deltaTime
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
            _enemyController.NextWaypoint();
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
        return (_timer > _enemyController.patrolStayTime);
    }
}
