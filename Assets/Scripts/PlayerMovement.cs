using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Jump,
    Fall
};

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidBody;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private CharacterAnimation characterAnimation;
    [SerializeField, Range(0f,10f)]
    private float playerSpeed = 5f;
    [SerializeField, Range(0f, 5f)]
    private float motionSpeed = 1f;
    private PlayerState currentState;

    private void Start()
    {
        SetState(PlayerState.Idle);
        SetMotionSpeed(motionSpeed);
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0 && forwardInput == 0)
        {
            SetState(PlayerState.Idle);
            return;
        }

        forwardInput = Mathf.Clamp01(forwardInput);

        Vector3 velocity = new Vector3(horizontalInput,0f,forwardInput);
        Vector3 movement =  velocity * (playerSpeed * Time.fixedDeltaTime);
        Vector3 newPos = playerTransform.position + movement;
        
        SetState(PlayerState.Run);
        playerRigidBody.MovePosition(newPos);
    }

    private void SetState(PlayerState s)
    {
        if (s == currentState)
        {
            return;
        }
        currentState = s;

        switch(s)
        {
            case PlayerState.Idle:
                characterAnimation.SetState(CharacterState.Idle);
                break;
            case PlayerState.Walk:
                characterAnimation.SetState(CharacterState.Walk);
                break;
            case PlayerState.Run:
                characterAnimation.SetState(CharacterState.Run);
                break;
            default: 
                break;
        }
    }

    private void SetMotionSpeed(float ms)
    {
        characterAnimation.SetMotionSpeed(ms);
    }
}
