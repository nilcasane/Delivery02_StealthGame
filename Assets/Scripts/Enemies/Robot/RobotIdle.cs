using UnityEngine;

public class RobotIdle : StateMachineBehaviour
{
    private float _timer;
    private EnemyVision _enemyVision;
    private RobotController _controller;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _controller = animator.GetComponent<RobotController>();
        _enemyVision = animator.GetComponent<EnemyVision>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerDetected = _enemyVision.IsPlayerDetected;
        var timeUp = IsTimeUp();

        animator.SetBool("IsChasing", playerDetected);
        animator.SetBool("IsPatroling", timeUp);
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > _controller.IdleDuration);
    }
}
