//using HoloToolkit.Sharing;
using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class HologramPlacement : Singleton<HologramPlacement> {
    /// <summary>
    /// Tracks if we have been sent a transform for the model.
    /// The model is rendered relative to the actual anchor.
    /// </summary>
    public bool GotTransform { get; private set; }
    public GameObject mapObj;

    void Start() {
        // Start by making the model as the cursor.
        // So the user can put the hologram where they want.
        GestureManager.Instance.OverrideFocusedObject = this.gameObject;
    }

    void Update() {
        if (!GotTransform) {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMappingManager.Instance.LayerMask)) {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                transform.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                transform.rotation = toQuat;
            }
        }
    }

    public void OnSelect() {
        // Note that we have a transform.
        GotTransform = true;

        // The user has now placed the hologram.
        // Route input to gazed at holograms.
        GestureManager.Instance.OverrideFocusedObject = null;

        

        Instantiate(mapObj, transform.position, transform.rotation);
        Destroy(this);
    }

    public void ResetStage() {
        // We'll use this later.
    }
}