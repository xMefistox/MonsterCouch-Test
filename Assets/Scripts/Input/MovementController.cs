using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MonsterCouchTest.Input
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private float _movementSpeed = 1f;

        private Vector2 movement;

        private void Awake()
        {
            _collider.enabled = false;
        }

        internal void Move(Vector2 movementInput)
        {
            if(_collider.enabled == false)
            {
                _collider.enabled = true;
            }
            movement = movementInput * _movementSpeed;
            transform.position += new Vector3(movementInput.x, movement.y, transform.position.z) * Time.fixedDeltaTime;
        }
    }
}