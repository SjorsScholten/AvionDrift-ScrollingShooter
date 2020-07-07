using Entities;
using UnityEngine;

namespace Ship.Entities {
    public class Ship {
        private readonly ShipData _data;
        private readonly IShipController _controller;
        
        private float _currentHealth;
        
        public Vector3 Velocity { get; private set; } = Vector3.zero;
        
        private Element _currentElement;
        private BaseWeapon _currentWeapon;
        
        //Flags
        //private bool _dead;
        
        public Ship(IShipController controller, ShipData data) {
            _controller = controller;
            _data = data;
            Initialize();
        }

        public void Initialize() {
            _currentHealth = _data.Health;
            _currentElement = _data.Elements[0];
            _currentWeapon = _data.Weapons[0];
        }

        /*
        public void TakeHit(DamageData damage) {
            if (_currentElement.Weaknesses.Contains(damage.element)) damage.amount *= 1.5f;
            if (_currentElement.Resistances.Contains(damage.element)) damage.amount *= 0.5f;
            
            _currentHealth -= damage.amount;

            if (_currentHealth <= 0) this.Die();
        }

        private void Die() {
            if (!_dead) {
                _dead = true;
                
                //TODO: implement dieing;
            }
        }
        */
        
        public void MoveTowards(Vector3 direction, float deltaTime) {
            if(direction == Vector3.zero) return; //dont need to move to its current position
            _controller.ProcessMovePosition(direction * _data.Agility * deltaTime);
        }

        public void FireWeapon(Vector3 position, float deltaTime) => _currentWeapon.Fire(position, _currentElement, deltaTime);

        public void ChangeElement(int elementIndex) {
            _currentElement = _data.Elements[elementIndex];
            _controller.ProcessElementChanged(_currentElement);
        }

        public void ChangeWeapon(int weaponIndex) {
            _currentWeapon = _data.Weapons[weaponIndex];
            _controller.ProcessWeaponChanged(_currentWeapon);
        }

        
    }
}