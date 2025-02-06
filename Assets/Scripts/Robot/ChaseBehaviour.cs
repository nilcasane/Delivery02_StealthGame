using UnityEngine;

public class ChaseBehaviour : StateMachineBehaviour
{
    public float Speed;
    private Transform _player;
    private EnemyVision _enemyVision;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyVision = animator.GetComponent<EnemyVision>();

    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move to player
        Vector2 dir = _player.position - animator.transform.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;
        //animator.transform.Rotate(0,0,);

        // Check
        var playerClose = _enemyVision.IsPlayerDetected;
        animator.SetBool("IsChasing", playerClose);
    }
}
