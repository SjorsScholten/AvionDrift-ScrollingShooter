using System;
using UnityEngine;

namespace CartAndRailSystem.Controllers {
    public class Cart {
        private readonly CartController _controller;
        
        private float _speed = 5f;

        public Cart(CartController controller) {
            _controller = controller;
        }
    }
}