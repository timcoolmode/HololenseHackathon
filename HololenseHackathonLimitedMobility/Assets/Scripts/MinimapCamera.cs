using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour
{

    public GameObject target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
    }

}