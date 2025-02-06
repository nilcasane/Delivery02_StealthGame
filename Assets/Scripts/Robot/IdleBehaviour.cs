using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float StayTime;

    private float _timer;
    private EnemyVision _enemyVision;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _enemyVision = animator.GetComponent<EnemyVision>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerClose = _enemyVision.IsPlayerDetected;
        var timeUp = IsTimeUp();

        animator.SetBool("IsChasing", playerClose);
        animator.SetBool("IsPatroling", timeUp);
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > StayTime);
    }
}
