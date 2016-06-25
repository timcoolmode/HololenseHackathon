using UnityEngine;
using System.Collections;
using System.Linq;

public class NavPath: MonoBehaviour {
    public Transform target;
    public GameObject trailObj;
    public GameObject waypointObj;
    public GameObject debugObj;
    public float speed;

    NavMeshAgent agent;
    NavMeshPath path;
    GameObject[] waypoints;

    bool hasPath = false;
    int currPoint = 0;

    // Use this for initialization
    void Start () {
        //agent = GetComponent<NavMeshAgent>();
        //path = new NavMeshPath();
        //agent.CalculatePath(target.position, path);
        FindWaypoints();
        InitializeAnimation();
    }
	
	// Update is called once per frame
	void Update () {
        if (hasPath) {
            float step = speed * Time.deltaTime;
            trailObj.transform.position = Vector3.MoveTowards(trailObj.transform.position, waypoints[currPoint].transform.position, step);
            if (trailObj.transform.position == waypoints[currPoint].transform.position) {
                WaypointReached();
            }
        }
    }

    void WaypointReached() {
        Instantiate(waypointObj, trailObj.transform.position, Quaternion.identity);
        if (currPoint < (waypoints.Length - 1)) {
            currPoint++;
        }
        else {
            // end reached
            hasPath = false;
            RestartAnimation();
        }
    }

    void InitializeAnimation() {
        //if (path.status == NavMeshPathStatus.PathComplete) {
            trailObj = (GameObject)Instantiate(trailObj, transform.position, Quaternion.identity);
            hasPath = true;

            foreach (GameObject waypoint in waypoints) {
                Instantiate(debugObj, waypoint.transform.position, Quaternion.identity);
            }
        //}
    }

    void RestartAnimation() {
        hasPath = true;
        currPoint = 0;
        InitializeAnimation();
    }

    void FindWaypoints() {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
    }
}
