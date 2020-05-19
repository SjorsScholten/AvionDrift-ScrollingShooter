using UnityEngine;

namespace Entities {
    [CreateAssetMenu(fileName = "New Element", menuName = "Element")]
    public class Element : ScriptableObject{
        [SerializeField] private Color _color;
        
        //shield attributes
        [SerializeField] private Element[] _weaknesses;
        [SerializeField] private Element[] _resistances;

        public Element[] Weaknesses => _weaknesses;
        public Element[] Resistances => _resistances;
    }
}