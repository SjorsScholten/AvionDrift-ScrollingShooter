using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace CartAndRailSystem.Controllers {
    public class CartController : MonoBehaviour {
        public RailController railController;

        private Point CURRENT_point;

        public Transform myTransform { get; private set; }

        private void Awake() {
            myTransform = GetComponent<Transform>();
            CURRENT_point = railController.rail.GetPoint();
        }

        private void Update() {
            CheckPosition();
            myTransform.position =
                Vector3.MoveTowards(myTransform.position, CURRENT_point.position, 5 * Time.deltaTime);
        }

        private void CheckPosition() {
            if (myTransform.position == CURRENT_point.position) {
                CURRENT_point = railController.rail.GetNextPoint();
            }
        }
    }
}