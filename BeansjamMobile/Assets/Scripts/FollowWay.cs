using System.Collections;
using UnityEngine;

public class FollowWay : MonoBehaviour, IEnemyBehaviour {

    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform enemy;
    public float startDelay; 

    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private Vector3 nextWaypoint;
    private int currentWaypoint = 0;
    private int increment = 1;

    void Start () {
        StartCoroutine(DelayStartCoroutine());
	}

    private void ShiftWayPoints(Vector3 offset)
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].position += offset;
        }
        // update current waypoint
        if(currentWaypoint < waypoints.Length)
            nextWaypoint = waypoints[currentWaypoint].position;
    }

    public void Stop()
    {
        StopAllCoroutines();
        Reset();
    }

    private void Reset()
    {
        currentWaypoint = 0;
        nextWaypoint = waypoints[1].position;
        enemy.transform.position = waypoints[currentWaypoint].position;
        currentWaypoint++;
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator DelayStartCoroutine()
    {
        yield return new WaitForSeconds(startDelay);
        Reset();
    }

    private IEnumerator MoveCoroutine()
    {
        bool bMove = true;
        while (bMove)
        {
            enemy.transform.forward = Vector3.RotateTowards(enemy.transform.forward, nextWaypoint - enemy.transform.position, rotateSpeed * Time.deltaTime, 0.0f);
            // move towards the target
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, nextWaypoint, moveSpeed * Time.deltaTime);

            if (enemy.transform.position == nextWaypoint)
            {
                
                if (currentWaypoint + increment >= waypoints.Length || currentWaypoint + increment < 0)
                    increment *= -1;

                currentWaypoint += increment;
                nextWaypoint = waypoints[currentWaypoint].position;
            }
            yield return 0;
        }
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}
