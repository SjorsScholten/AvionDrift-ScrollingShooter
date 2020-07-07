using UnityEngine;

namespace Diorama.Controllers {
    public abstract class Diorama {
        protected readonly DioramaController controller;

        protected Bounds bounds;
        protected Vector3 TMP_Vector = Vector3.zero;

        public Diorama(DioramaController controller) => this.controller = controller;

        protected struct Bounds {
            public Vector3 bottomLeft;
            public Vector3 topRight;

            public Bounds(Vector3 bottomLeft, Vector3 topRight) {
                this.bottomLeft = bottomLeft;
                this.topRight = topRight;
            }
        }

        public void UpdateDioramaBounds(Camera camera) {
            var distance = Vector3.Distance(camera.transform.position, controller.myTransform.position);
            var bottomLeft = controller.myTransform.InverseTransformPoint(camera.ViewportToWorldPoint(new Vector3(0,0,distance)));
            var topRight = controller.myTransform.InverseTransformPoint(camera.ViewportToWorldPoint(new Vector3(1,1, distance)));
            bounds = new Bounds(bottomLeft, topRight);
        }

        public abstract Vector3 TransformDirection(Vector3 input);
        public abstract Vector3 ClampPosition(Vector3 position);
    }
}