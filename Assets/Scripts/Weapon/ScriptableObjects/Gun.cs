using UnityEngine;

namespace Entities {
    
    [CreateAssetMenu(fileName = "new gun", menuName = "Weapon/Gun")]
    public class Gun : BaseWeapon {
        public float rateOfFire;
        public float projectileSpeed;
        
        public override void Fire(Vector3 position, Element element) {
            //ProjectilePool.Instance.Get().Fire(position, Vector3.forward * 10, 2f);
        }
    }
}