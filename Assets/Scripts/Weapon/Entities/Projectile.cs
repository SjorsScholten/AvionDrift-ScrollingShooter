using Entities;
using UnityEngine;
using Weapon.Controllers;
using Weapon.ScriptableObjects;

namespace Weapon.Entities {
    public class Projectile {
        private readonly IProjectileController _controller;

        private ProjectileData _data;

        public Projectile(IProjectileController controller) {
            this._controller = controller;
        }

        public void Initialize(ProjectileData data) {
            _data = data;
        }
        
        public void MovePosition(float deltaTime) {
            var speed = _data.initialSpeed * deltaTime;
            var velocity = Vector3.forward * speed;
            _controller.ProcessMovePosition(velocity);
        }
    }
}