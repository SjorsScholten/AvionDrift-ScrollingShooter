using UnityEngine;

namespace Entities {
    [CreateAssetMenu(fileName = "New Element", menuName = "Element")]
    public class Element : ScriptableObject{
        [SerializeField] private Color _color = Color.white;
        
        //shield attributes
        [SerializeField] private Element[] _weaknesses = null;
        [SerializeField] private Element[] _resistances = null;

        public Element[] Weaknesses => _weaknesses;
        public Element[] Resistances => _resistances;
    }
}