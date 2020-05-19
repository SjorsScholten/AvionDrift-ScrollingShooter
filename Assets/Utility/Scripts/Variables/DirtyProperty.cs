using System;

namespace Utility.Scripts.Variables {
    [Serializable]
    public abstract class DirtyProperty<T> {
        private T _baseValue;
        private T _value;
        
        public T Value {
            get {
                if (CheckValue()) _value = UpdateValue();
                return _value;
            }
        }

        protected abstract bool CheckValue();
        protected abstract T UpdateValue();

        public static implicit operator T(DirtyProperty<T> v) => v.Value;
    }
}