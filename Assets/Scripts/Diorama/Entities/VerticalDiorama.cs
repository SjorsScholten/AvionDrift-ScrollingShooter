using UnityEngine;

namespace Diorama.Controllers {
    public class VerticalDiorama : Diorama {
        
        public VerticalDiorama(DioramaController controller) : base(controller) {}
        
        public override Vector3 ClampPosition(Vector3 position) {
            return Vector3.zero;
        }

        public override Vector3 TransformDirection(Vector3 input) {
            TMP_Vector.Set(0, input.y, input.x);
            return TMP_Vector;
        }
    }
}