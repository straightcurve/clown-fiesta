using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core.Movement {

    public class Movement : MonoBehaviour {

        public float Speed {
            get => _speed;
            set => _speed = value;
        }
        [SerializeField] private float _speed = 10f;

        public bool CanMove { get; set; }
        public bool CanRotate { get; set; }

        private Rigidbody2D rigidbody;
        public Vector2 Direction {
            get => _direction;
            set => _direction = value.normalized;
        }
        private Vector2 _direction;

        public Vector2 FacingDirection => _latestFacingDirection;
        private Vector2 _latestFacingDirection;

        protected virtual void OnEnable() {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate() {
            if (CanRotate)
                rigidbody.rotation = Vector2.SignedAngle(new Vector2(0, -1), _latestFacingDirection);

            //  -1,  1 => 225
            //   0,  1 => 180
            //   1,  1 => 135
            //  -1,  0 => 270
            //   0,  0 => 0
            //   1,  0 => 90
            //  -1, -1 => 315
            //   0, -1 => 0
            //   1, -1 => 45

            if (!CanMove)
                return;

            rigidbody.position += _direction * Speed * Time.fixedDeltaTime;
        }

        protected virtual void Update() {
            if (Direction.normalized.magnitude == 0f)
                return;

            if (!CanRotate && !CanMove)
                return;

            //  cache latest direction
            _latestFacingDirection = Direction.normalized;
        }
    }
}
