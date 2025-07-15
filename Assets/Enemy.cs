using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        // Grab the first waypoint from the static array created in Waypoints.cs
        target = Waypoints.points[0];
    }

    void Update()
    {
        // 1. Move toward the current target
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // 2. If we’re close enough, switch to the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    /// <summary>
    /// Advances to the next waypoint; destroys the enemy if we’ve reached the end.
    /// </summary>
    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);   // Reached the end of the path
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
