using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Util;

namespace Diorama.Controllers {
    public class DioramaController : Singleton<DioramaController> {
        private Diorama CURRENT_diorama;
        [HideInInspector] public Transform myTransform;

        private void Awake() {
            myTransform = GetComponent<Transform>();
            CURRENT_diorama = new HorizontalDiorama(this);
            CURRENT_diorama.UpdateDioramaBounds(Camera.main);
        }

        public Diorama Diorama => CURRENT_diorama;
    }
}