using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	
	}

    public void StartEverything() {
        Debug.Log("StartEverything");

        var miniMapCanvas = GameObject.FindGameObjectWithTag("MiniMapCanvas").GetComponent<AnimateMiniMap>();
        miniMapCanvas.buttonPress();
        var alerts = GameObject.FindGameObjectWithTag("AlertCanvas").GetComponent<Animations>();
        alerts.buttonPress();

    }
	// Update is called once per frame
	void Update () {
	
	}
}
