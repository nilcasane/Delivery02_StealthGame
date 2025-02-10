using UnityEngine;

public class CameraIdle : StateMachineBehaviour
{
    private float _timer;
    private EnemyVision _enemyVision;
    private CameraController _controller;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller = animator.GetComponent<CameraController>();
        _enemyVision = animator.GetComponent<EnemyVision>();
        _timer = 0.0f;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerClose = _enemyVision.IsPlayerDetected;
        var timeUp = IsTimeUp();

        //animator.SetBool("IsPlayerKilled", playerClose);
        animator.SetBool("IsPatroling", timeUp);
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > _controller.idleDuration);
    }
}
