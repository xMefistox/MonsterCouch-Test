using System;
using UnityEngine;

namespace MonsterCouchTest.Input
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _movementSpeed = 1f;

        private Vector2 movement;

        internal void Move(Vector2 movementInput)
        {
            movement = movementInput * _movementSpeed;
            _rigidbody.MovePosition(_rigidbody.position + movement * Time.fixedDeltaTime);
        }
    }
}