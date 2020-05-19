using Entities;
using UnityEngine;
using Util;
using Weapon.Entities;

namespace Weapon.Controllers {
    public class ProjectileController : Entity {
        private Projectile _projectile;
    
        protected override void Initialize() {
            
        }

        private void Update() {
            
        }

        private void FixedUpdate() {
            //update Physics if necessary
            //Update Projectile Position
        }

        private void OnCollisionEnter(Collision other) {
            //hit detection handling
            //if hit player
            //if hit wall
            //if hit projectile
            //if hit etc
        }
    }
}
