using Entities;
using UnityEngine;
using Util;
using Weapon.Entities;
using Weapon.ScriptableObjects;

namespace Weapon.Controllers {
    public class ProjectileController : Entity, IProjectileController {
        private Projectile _projectile;
    
        protected override void Initialize() {
            _projectile = new Projectile(this);
            myRigidbody.useGravity = false;
        }

        private void OnEnable() {
            Invoke(nameof(ReturnToPool), 3f);
        }
        
        private void ReturnToPool() => ProjectilePool.Instance.ReturnToPool(this);

        private void FixedUpdate() {
            //update Physics if necessary
            _projectile.MovePosition(Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision other) {
            //hit detection handling
            //if hit player
            //if hit wall
            //if hit projectile
            //if hit etc
        }

        public void ProcessMovePosition(Vector3 velocity) {
            var newPosition = myTransform.TransformPoint(velocity);
            myRigidbody.MovePosition(newPosition);
        }

        public void ProcessFire(ProjectileData projectileData, Vector3 position, Element element) {
            _projectile.Initialize(projectileData);
            myTransform.position = position;
            myGameObject.SetActive(true);
            //reset position and rotation
            //reset projectile
            //bind data to projectile
        }
    }

    public interface IProjectileController {
        void ProcessMovePosition(Vector3 velocity);
    }
}
