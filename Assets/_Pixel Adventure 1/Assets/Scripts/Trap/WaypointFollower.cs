using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints;
    [SerializeField] private int curIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[curIndex].transform.position, transform.position) < .1f)
        {
            ++curIndex;
            if (curIndex >= waypoints.Count)
            {
                curIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[curIndex].transform.position, speed * Time.deltaTime);
    }
}
