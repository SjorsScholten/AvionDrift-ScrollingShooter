using UnityEngine;

namespace Entities {
    public interface IShipController {
        //void ProcessThrusterForce(Vector3 force);
        void ProcessMovePosition(Vector3 position);
        void ProcessElementChanged(Element element);
        void ProcessWeaponChanged(BaseWeapon weapon);
    }
}