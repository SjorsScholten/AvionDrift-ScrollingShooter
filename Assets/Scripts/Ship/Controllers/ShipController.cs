using Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.Variables;

namespace Ship.Controllers {
    public enum ElementType { Red, Yellow, Purple }
    
    public class ShipController : Entity, Controls.IShipActions, IShipController {
        public ShipData initialShipData;
        public new Camera camera;
        
        private Ship.Entities.Ship _ship;
        private Vector2 _moveDirection;
        private IndexCycle _weaponIndex, _elementIndex;
        
        protected override void Initialize() {
            _ship = new Ship.Entities.Ship(this, initialShipData);
            myRigidbody.mass = initialShipData.Mass;
            
            //_weaponIndex = new IndexCycle(_data.Weapons.Length);
            //_elementIndex = new IndexCycle(_data.Elements.Length);
        }

        private void FixedUpdate() {
            HandleMoveShip();
        }
        
        public void OnMove(InputAction.CallbackContext context) {
            _moveDirection = context.ReadValue<Vector2>();
        }

        public void OnFire(InputAction.CallbackContext context) {
            if(context.performed) _ship.FireWeapon(myTransform.forward);
        }

        //public void HandleNextElement() => _ship.ChangeElement(_elementIndex.Next()); //switch next element in line

        //public void HandlePreviousElement() => _ship.ChangeElement(_elementIndex.Previous()); //switch previous element in line
        
        //public void SwitchWeapon() => _ship.ChangeWeapon(_weaponIndex.Next());

        private void HandleMoveShip() {
            _ship.MoveTowards(camera.transform.TransformDirection(_moveDirection), 
                Time.fixedDeltaTime);
        }

        /*
        public void ProcessThrusterForce(Vector3 force) {
            myRigidbody.AddForce(force, ForceMode.Force);
        }
        */

        public void ProcessMovePosition(Vector3 position) {
            var newPosition = myTransform.TransformPoint(position);
            
            var TMP_viewportPosition = camera.WorldToViewportPoint(newPosition);
            TMP_viewportPosition.x = Mathf.Clamp01(TMP_viewportPosition.x);
            TMP_viewportPosition.y = Mathf.Clamp01(TMP_viewportPosition.y);
            
            newPosition = camera.ViewportToWorldPoint(TMP_viewportPosition);
            
            myRigidbody.MovePosition(newPosition);
        }

        //set color of ship and update UI
        public void ProcessElementChanged(Element element) { }

        //Update UI
        public void ProcessWeaponChanged(BaseWeapon weapon) { }
    }
}