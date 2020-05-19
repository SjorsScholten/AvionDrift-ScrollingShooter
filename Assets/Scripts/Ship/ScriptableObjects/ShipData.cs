using UnityEngine;

namespace Entities {
    [CreateAssetMenu(fileName = "new Ship", menuName = "Ship")]
    public class ShipData : ScriptableObject {
        //stats
        [SerializeField] private float _vitality = 1;
        [SerializeField] private float _agility = 1;

        [SerializeField] private float _mass = 1;

        [SerializeField] private Element[] _elements;
        [SerializeField] private BaseWeapon[] _weapons;
        
        //public Gear[] gear;

        public float Vitality => _vitality;
        public float Agility => _agility;

        public Element[] Elements => _elements;
        public BaseWeapon[] Weapons => _weapons;
        public float Health => _vitality * 10;

        public float Mass => _mass;
    }
}