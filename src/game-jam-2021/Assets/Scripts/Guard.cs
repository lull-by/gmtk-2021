using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed = 5;
    public float waitTime = .3f;
    public float turnSpeed = 90;

    public Transform pathHolder;
    GameObject parentObject;
    GameObject childObject;

    private void Start()
    {
        parentObject = GameObject.Find("Guard");// The name of the parent object
        childObject = parentObject.transform.GetChild(0).gameObject; // the parent index (starting from 0)
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;

        }

        StartCoroutine(FollowPath(waypoints));
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWayPoint = waypoints[targetWaypointIndex];
        childObject.transform.LookAt(targetWayPoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
            if((Vector3) transform.position == targetWayPoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWayPoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurntoFace(targetWayPoint));
            }
            yield return null;
        }
    }

    IEnumerator TurntoFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - childObject.transform.position).normalized;
        float targetAngle = -90 + Mathf.Atan2(dirToLookTarget.x, dirToLookTarget.y) * Mathf.Rad2Deg;

        while (Mathf.DeltaAngle(childObject.transform.eulerAngles.x, targetAngle) > 0.05);
        {
            float angle = Mathf.MoveTowardsAngle(childObject.transform.eulerAngles.x, targetAngle, turnSpeed + Time.deltaTime);
            childObject.transform.eulerAngles = new Vector3(angle, 90, 0);
            yield return null;

        }
    }


    private void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
