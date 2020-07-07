using CartAndRailSystem.Controllers;
using Diorama.Controllers;
using Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.Variables;

namespace Ship.Controllers {
    public enum ElementType { Red, Yellow, Purple }
    
    public class ShipController : Entity, Controls.IShipActions, IShipController {
        public ShipData initialShipData;
        private DioramaController dioramaController;
        public CartController cart;
        
        private Ship.Entities.Ship _ship;
        private Vector2 _moveDirection;
        private IndexCycle _weaponIndex, _elementIndex;

        private bool _isFiring;

        [SerializeField] private Vector3 worldPosition;
        
        protected override void Initialize() {
            dioramaController = DioramaController.Instance;
            _ship = new Ship.Entities.Ship(this, initialShipData);
            myRigidbody.mass = initialShipData.Mass;
        }

        private void Update() {
            if(_isFiring) _ship.FireWeapon(myTransform.TransformPoint(myTransform.forward), Time.deltaTime);
        }

        private void FixedUpdate() {
            //_ship.MoveTowards(dioramaController.Diorama.TransformDirection(_moveDirection), Time.fixedDeltaTime);
            ProcessAddForce();
        }
        
        public void OnMove(InputAction.CallbackContext context) {
            _moveDirection = context.ReadValue<Vector2>();
        }

        public void OnFire(InputAction.CallbackContext context) {
            if (context.performed) _isFiring = context.ReadValueAsButton();
        }
        
        public void ProcessMovePosition(Vector3 velocity) {
            /*worldPosition = myTransform.TransformPoint(localPosition);
            worldPosition = dioramaController.Diorama.ClampPosition(worldPosition);
            myRigidbody.MovePosition(worldPosition);*/
        }

        public void ProcessAddForce() {
            var finalVelocity = dioramaController.Diorama.TransformDirection(_moveDirection) * 5;
            var force = (finalVelocity - myRigidbody.velocity) / Time.fixedDeltaTime;
            myRigidbody.AddRelativeForce(force * myRigidbody.mass, ForceMode.Force);
        }

        //set color of ship and update UI
        public void ProcessElementChanged(Element element) { }

        //Update UI
        public void ProcessWeaponChanged(BaseWeapon weapon) { }
    }
}