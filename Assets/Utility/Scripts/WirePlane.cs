using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlane : MonoBehaviour {
    public Color color = Color.green;
    private void OnDrawGizmos() {
        var TEMP_transform = transform;
        Gizmos.color = color;
        Gizmos.DrawWireCube(TEMP_transform.position, TEMP_transform.lossyScale);
    }
}
