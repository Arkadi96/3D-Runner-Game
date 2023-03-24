using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckPointHit();

public class PlayerCollision : MonoBehaviour
{
    public event CheckPointHit OnCheckPointHitEvent;

    private void OnCollisionExit(Collision collision)
    {
        OnCheckPointHitEvent?.Invoke();
    }
}
