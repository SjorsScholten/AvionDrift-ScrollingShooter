using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point {
    public Vector3 position;
    public List<PointEvent> events = new List<PointEvent>();

    public void OnEnter() { }

    public void OnExit() { }
}