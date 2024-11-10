using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump(bool isJump)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsJump, isJump);
    }

    public void Fall(bool isFall)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsFall, isFall);
    }

    public void Run(bool isRun)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, isRun);
    }
}
