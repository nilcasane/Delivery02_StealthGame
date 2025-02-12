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
        _player = _controller.player.transform;
        _rb = _controller.RigidBody;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move to player
        Vector2 targetPosition = _player.position;
        _rb.MovePosition(
            Vector2.MoveTowards(
                animator.transform.position,
                targetPosition,
                _controller.chaseSpeed * Time.deltaTime)
        );

        // Rotación con Quaternion
        Vector2 direction = targetPosition - (Vector2)animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _rb.MoveRotation(Quaternion.RotateTowards(animator.transform.rotation, targetRotation, 5000 * Time.deltaTime));

        // Check
        var playerDetected = _enemyVision.IsPlayerDetected || _controller.PlayerDetected;
        animator.SetBool("IsChasing", playerDetected);
    }
}
