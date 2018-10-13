using System.Collections;
using UnityEngine;

public class FollowWay : MonoBehaviour {

    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private Transform pantomime;
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private Vector3 nextWaypoint;
    private int currentWaypoint = 0;

    [Range(-10, 10)]
    public int offsetIncrement = 0;
    public Vector3 offset;

    void Start () {
        Reset();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && offsetIncrement > -10)
        {
            offsetIncrement--;
            ShiftWayPoints(-offset);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && offsetIncrement < 10)
        {
            offsetIncrement++;
            ShiftWayPoints(offset);
        }

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
        ShiftWayPoints(offsetIncrement * -offset);
        offsetIncrement = 0;

        currentWaypoint = 0;
        nextWaypoint = waypoints[1].position;
        pantomime.position = waypoints[currentWaypoint].position;
        currentWaypoint++;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        bool bMove = true;
        while (bMove)
        {
            pantomime.forward = Vector3.RotateTowards(pantomime.forward, nextWaypoint - pantomime.position, rotateSpeed * Time.deltaTime, 0.0f);
            // move towards the target
            //pantomime.position = Vector3.MoveTowards(pantomime.position, nextWaypoint, moveSpeed * Time.deltaTime);
            pantomime.position += Vector3.forward * moveSpeed * Time.deltaTime;

            if (pantomime.position.z >= nextWaypoint.z)
            {
                if (++currentWaypoint < waypoints.Length)
                {
                    nextWaypoint = waypoints[currentWaypoint].position;
                }
                else
                {
                    //bMove = false;
                    Stop();
                }

            }
            yield return 0;
        }
    }
}
