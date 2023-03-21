using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Range(2.5f, 7.5f)]
    private float speed = 5f;
    [SerializeField]
    private Transform sourceTransform;
    [SerializeField]
    private Transform targetTransform;

    private Vector3 initialDistance;

    void Start()
    {
        initialDistance = sourceTransform.position - targetTransform.position;
    }

    void LateUpdate()
    {
        sourceTransform.position = Vector3.Lerp(sourceTransform.position, targetTransform.position + initialDistance, Time.deltaTime * speed);
    }


}
