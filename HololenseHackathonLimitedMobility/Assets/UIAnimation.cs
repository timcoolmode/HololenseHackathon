using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour {
    
    
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        var Minimap = GameObject.Find("/MiniMap");
        var Alert = GameObject.Find("/Alert");
        

        Alert.SetActive(true);

        

        if (Time.time == 15)
        {

        }
        if (Time.time == 20)
        {

        }
	}
}
