using System;

namespace Util.Variables {
    public class IndexCycle {
        public int Index { get; set; } = 0;
        private readonly int _length = 0;

        public event Action OnIndexChanged;

        public IndexCycle(int length) {
            _length = length;
        }

        public IndexCycle Next() {
            if(!CheckLength()) return null;
            Index++;
            if (Index > _length - 1) Index = 0;
            OnIndexChanged?.Invoke();
            return this;
        }

        public IndexCycle Previous() {
            if(!CheckLength()) return null;
            Index--;
            if (Index < 0) Index = _length - 1;
            OnIndexChanged?.Invoke();
            return this;
        }

        private bool CheckLength() {
            switch (_length) {
                case 0:
                    return false;
                case 1:
                    Index = 0;
                    return false;
                default:
                    return true;
            }
        }

        public static implicit operator int(IndexCycle v) => v.Index;
    }
}