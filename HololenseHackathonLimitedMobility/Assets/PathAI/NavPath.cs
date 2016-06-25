using UnityEngine;using System.Collections;public class NavPath: MonoBehaviour {    public Transform target;    public GameObject trailObj;    public float speed;    NavMeshAgent agent;    NavMeshPath path;    bool hasPath = false;
    int currPoint = 0;

    // Use this for initialization
    void Start () {        agent = GetComponent<NavMeshAgent>();        path = new NavMeshPath();        agent.CalculatePath(target.position, path);        if (path.status == NavMeshPathStatus.PathComplete) {            trailObj = (GameObject)Instantiate(trailObj, transform.position, Quaternion.identity);            hasPath = true;        }    }		// Update is called once per frame	void Update () {        if (hasPath) {
            float step = speed * Time.deltaTime;
            trailObj.transform.position = Vector3.MoveTowards(trailObj.transform.position, path.corners[currPoint], step);
            if (trailObj.transform.position == path.corners[currPoint]) {
                WaypointReached();
            }
        }    }    void WaypointReached() {
        if (currPoint < (path.corners.Length - 1)) {
            currPoint++;
        } else {
            // end reached
        }
    }}