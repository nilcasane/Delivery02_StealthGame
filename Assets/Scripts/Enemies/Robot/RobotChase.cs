using UnityEngine;

public class RobotChase : StateMachineBehaviour
{
    private Transform _player;
    private EnemyVision _enemyVision;
    private RobotController _controller;
    private Rigidbody2D _rb;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyVision = animator.GetComponent<EnemyVision>();
        _controller = animator.GetComponent<RobotController>();
        _player = _controller.player;
        _rb = _controller.RigidBody;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move to player
        _rb.MovePosition(
            Vector2.MoveTowards(
                animator.transform.position,
                _player.position,
                _controller.chaseSpeed * Time.deltaTime)
        );
        _rb.rotation = Mathf.Atan2(_player.position.x, _player.position.y) * Mathf.Rad2Deg;
        /* Quaternion targetRotation = Quaternion.LookRotation(_player.position);
        Quaternion rotation = Quaternion.RotateTowards(animator.transform.rotation, targetRotation, 5 * Time.deltaTime);
        */
        //_rb.MoveRotation(rotation);
        //animator.transform.rotation = rotation;

        // Check
        var playerClose = _enemyVision.IsPlayerDetected;
        animator.SetBool("IsChasing", playerClose);
    }
}
