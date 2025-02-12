using TMPro;
using UnityEngine;

public class CameraPatrol : StateMachineBehaviour
{
    private CameraController _controller;

    private Rigidbody2D _rb;
    private float _timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0.0f;
        _timer = 0.0f;
        _controller = animator.GetComponent<CameraController>();
        _rb = _controller.RigidBody;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Move
        if(_timer % _controller.RotationSpeed <= 1)
            _rb.MoveRotation(_controller.NextRotationAngle());
  
        // Check triggers
        var timeUp = IsTimeUp();
        animator.SetBool("IsPatroling", !timeUp);
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > _controller.PatrolStayTime);
    }
}
