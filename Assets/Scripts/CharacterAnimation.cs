using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Idle = 0,
    Walk = 2,
    Run = 6
};

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    private readonly int characterSpeed = Animator.StringToHash("Speed");
    private readonly int motionSpeed = Animator.StringToHash("MotionSpeed");


    public void SetState(CharacterState state)
    {
        playerAnimator.SetFloat(characterSpeed, (int)state);
    }

    public void SetMotionSpeed(float ms)
    {
        playerAnimator.SetFloat(motionSpeed, ms);
    }
}
