using UnityEngine;

namespace Entities {
    public abstract class BaseWeapon : ScriptableObject {
        public float minDamage, maxDamage;
        public float efficiency;
        public float decayFactor;
        public float regenDelay;
        public float regenSpeed;

        public abstract void Fire(Vector3 position, Element element, float deltaTime);

        protected void Decay() {
            
        }

        private void NormalDeviation() {
            //calculate mean, minDamage + (maxDamage - minDamage) * efficiency
            //standard deviation
        }
    }
}