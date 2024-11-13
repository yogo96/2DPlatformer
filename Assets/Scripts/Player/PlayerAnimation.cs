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
        _animator.SetBool(AnimatorData.Params.IsJump, isJump);
    }

    public void Fall(bool isFall)
    {
        _animator.SetBool(AnimatorData.Params.IsFall, isFall);
    }

    public void Run(bool isRun)
    {
        _animator.SetBool(AnimatorData.Params.IsRun, isRun);
    }

    public void Hit()
    {
        _animator.SetTrigger(AnimatorData.Params.IsHit);
    }
}
