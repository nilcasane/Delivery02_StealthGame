using UnityEngine;
using UnityEngine.UIElements;

public class ChaseBehaviour : StateMachineBehaviour
{
    private Transform _player;
    private EnemyVision _enemyVision;
    private EnemyController _enemyController;
    private Rigidbody2D _rb;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyVision = animator.GetComponent<EnemyVision>();
        _enemyController = animator.GetComponent<EnemyController>();
        _player = _enemyController.player;
        _rb = _enemyController.RigidBody;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move to player
        _rb.MovePosition(
            Vector2.MoveTowards(
                animator.transform.position,
                _player.position,
                _enemyController.chaseSpeed * Time.deltaTime)
        );
        _rb.rotation = Mathf.Atan2(_player.position.y, _player.position.x) * Mathf.Rad2Deg;

        // Check
        var playerClose = _enemyVision.IsPlayerDetected;
        animator.SetBool("IsChasing", playerClose);
    }
}
