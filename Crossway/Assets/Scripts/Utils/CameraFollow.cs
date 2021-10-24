using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Follow Settings")]
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform lookTarget;

    [Header("Start Follow")]
    public float followRadius = 0f;

    void FixedUpdate() {
        Vector3 lookPos = transform.position - offset;
        Vector3 desiredPosition;
        if ((target.transform.position - lookPos).magnitude > followRadius || followRadius <= 0) {
            desiredPosition = target.position + offset;
        }
        else
            desiredPosition = transform.position;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (lookTarget) {
            transform.LookAt(lookTarget);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        if (target)
            Gizmos.DrawWireSphere(target.position, followRadius);
    }

}