using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Controllers.Draft {
    public class DraftController : MonoBehaviour {
        public Draft _draft = new Draft();

        private void OnTriggerEnter(Collider other) => _draft.entities.Add(other.GetComponent<Entity>());
        private void OnTriggerExit(Collider other) => _draft.entities.Remove(other.GetComponent<Entity>());

        private void OnTriggerStay(Collider other) {
            _draft.ApplyDraft();
        }
    }

    [System.Serializable]
    public class Draft {
        public Vector3 direction = Vector3.up;
        public float force = Physics.gravity.y;
        public readonly List<Entity> entities = new List<Entity>();

        public void ApplyDraft() {
            foreach (var entity in entities) {
                entity.myRigidbody.AddForce(direction * force, ForceMode.Force);
            }   
        }
    }
}
