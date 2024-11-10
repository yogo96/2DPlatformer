using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsFall = Animator.StringToHash(nameof(IsFall));
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    }
}