using UnityEngine;using System.Collections;public class NavPath: MonoBehaviour {    public Transform target;    public GameObject trailObj;    NavMeshAgent agent;    bool hasPath = false;    NavMeshPath path = new NavMeshPath();

    // Use this for initialization
    void Start () {        agent = GetComponent<NavMeshAgent>();                agent.CalculatePath(target.position, path);        if (path.status == NavMeshPathStatus.PathComplete) {            Instantiate(trailObj, transform.position, Quaternion.identity);            foreach (Vector3 corner in path.corners) {                Debug.Log(corner);            }        }    }		// Update is called once per frame	void Update () {        if(hasPath) {

        }    }}