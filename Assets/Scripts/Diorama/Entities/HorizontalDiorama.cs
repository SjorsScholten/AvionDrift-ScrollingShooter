using UnityEngine;

namespace Diorama.Controllers {
    public class HorizontalDiorama : Diorama {
        
        public HorizontalDiorama(DioramaController controller) : base(controller) {}
        
        public override Vector3 ClampPosition(Vector3 worldPosition) {
            var localPosition = controller.myTransform.InverseTransformPoint(worldPosition);
            
            localPosition.Set(
                Mathf.Clamp(localPosition.x, bounds.bottomLeft.x, bounds.topRight.x),
                0f,
                Mathf.Clamp(localPosition.z, bounds.bottomLeft.z, bounds.topRight.z));
            
            return controller.myTransform.TransformPoint(localPosition);
        }

        public override Vector3 TransformDirection(Vector3 input) {
            TMP_Vector.Set(input.x, 0, input.y);
            return TMP_Vector;
        }
    }
}