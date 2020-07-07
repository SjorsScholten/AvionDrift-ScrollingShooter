using UnityEngine;
using Weapon.Entities;
using Weapon.ScriptableObjects;

namespace Entities {
    
    [CreateAssetMenu(fileName = "new gun", menuName = "Weapon/Gun")]
    public class Gun : BaseWeapon {
        public float rateOfFire;
        public ProjectileData projectileData;

        private float elapsedTime = 0;
        
        public override void Fire(Vector3 position, Element element, float deltaTime) {
            elapsedTime += deltaTime;
            if(elapsedTime < rateOfFire) return;
            
            ProjectilePool.Instance.Get().ProcessFire(projectileData, position, element);
            elapsedTime = 0;
        }
    }
}