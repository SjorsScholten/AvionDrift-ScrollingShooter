using UnityEditor;
using UnityEngine;

namespace CartAndRailSystem {
    
    [CustomEditor(typeof(RailController))]
    public class RailEditor : Editor {
        private RailController _controller;
        private Rail _rail;

        private void OnSceneGUI() {
            Draw();
        }

        private void Draw() {
            Handles.color = Color.red;
            foreach (var t in _rail.points) {
                var newPos = Handles.FreeMoveHandle(t.position, Quaternion.identity, .1f, Vector3.zero, Handles.CylinderHandleCap);
                
                if (t.position == newPos) continue;
                
                Undo.RecordObject(_controller, "Move Point");
                t.position = newPos;
            }
        }

        private void OnEnable() {
            _controller = target as RailController;
            if(_controller.rail == null) _controller.rail = new Rail();
            _rail = _controller.rail;
        }
    }
}