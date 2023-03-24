using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public delegate void HitCheckPointAction();

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerCollision playerCollision;
    [SerializeField]
    private PlayerHealth playerHealth;

    public event HitCheckPointAction OnLeftCheckPoint;

    private void OnEnable()
    {
        playerCollision.OnCheckPointHitEvent+= OnCheckPointHit;
    }

    private void OnDisable()
    {
        playerCollision.OnCheckPointHitEvent -= OnCheckPointHit;
    }

    private void OnCheckPointHit()
    {
        OnLeftCheckPoint?.Invoke();
    }
}

