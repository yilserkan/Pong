using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private Transform aiTransform = null;
    [SerializeField] private float moveSpeed = .2f;
    [SerializeField] private Vector2 boundaries = new Vector2();
    [SerializeField] private GameObject ball = null;
    [SerializeField] private LayerMask hitLayer = new LayerMask();

    private RaycastHit hit;
    
    void Update()
    {
        MoveToBallHitPoint();

    }

    private void MoveToBallHitPoint()
    {
        Physics.Raycast(ball.transform.position,
                ball.GetComponent<Rigidbody>().velocity.normalized,
                out hit,
                Mathf.Infinity,
                hitLayer);

        float distanceOfHitPoint = aiTransform.transform.position.y - hit.point.y;

        Debug.Log(distanceOfHitPoint);

        if( -0.05 <= distanceOfHitPoint && distanceOfHitPoint <= 0.05) { return; }

        float yDirOfHitPoint;

        if(distanceOfHitPoint < 0) {
            yDirOfHitPoint = 1;
        }
        else
        {
            yDirOfHitPoint = -1;
        }

        float newPlayerYPosition = Mathf.Clamp(
                        aiTransform.position.y + new Vector3(0f, yDirOfHitPoint * moveSpeed * Time.deltaTime, 0f).y,
                        boundaries.x, boundaries.y);

        aiTransform.position = new Vector3(aiTransform.transform.position.x, newPlayerYPosition, aiTransform.transform.position.z);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ball.transform.position, hit.point);
    }
}
