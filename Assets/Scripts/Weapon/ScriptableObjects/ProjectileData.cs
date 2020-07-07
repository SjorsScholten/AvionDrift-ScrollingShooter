using UnityEngine;

namespace Weapon.ScriptableObjects {
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile")]
    public class ProjectileData : ScriptableObject {
        public float initialSpeed;
    }
}