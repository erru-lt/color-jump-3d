using Assets.Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private float _yDirection;
        private float _moveDirection;

        private float _gravity;
        private float _verticalJumpVelocity;
        private readonly float _maxJumpHeight = 3.0f;
        private readonly float _maxJumpTime = 1f;
        private readonly float _doubleMultiplier = 2.0f;
        private readonly float _groundedGravity = -0.5f;
        private readonly float _horizontalJumpVelocity = 0.25f;

        private int _jumpCount;
        private readonly int _jumpCountMax = 2;

        private bool _isJumping;

        [SerializeField] private HeroGroundCheck _heroGroundCheck;
        [SerializeField] private CharacterController _characterController;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _heroGroundCheck.Landed += ResetJumpCount;
            SetupJumpVariables();
        }

        private void Update()
        {
            Movement();
            DoubleJump();
        }

        private void Movement()
        {
            Vector3 direction = new Vector3(0.0f, 0.0f, _moveDirection) * _moveSpeed;

            _yDirection += _gravity * Time.deltaTime;

            if (CanJump())
            {
                _yDirection = _groundedGravity;
                _moveDirection = transform.forward.z;
                Jumping();
            }

            StopJumping();
            Falling();

            direction.y = _yDirection;

            _characterController.Move(direction * Time.deltaTime);
        }

        private void Jumping()
        {
            if (_inputService.IsJumpButtonDown())
            {
                _isJumping = true;
                ReduceJumpCount();
                AddJumpVelocity();
            }
        }

        private void StopJumping()
        {
            if (_inputService.IsJumpButtonUp())
            {
                _isJumping = false;
            }
        }

        private void Falling()
        {
            if (_isJumping == false)
            {
                _yDirection += _gravity * _doubleMultiplier * Time.deltaTime;
            }
        }

        private void DoubleJump()
        {
            if (!_isJumping && _jumpCount > 0 && _inputService.IsJumpButtonDown())
            {
                _isJumping = true;
                ReduceJumpCount();
                AddJumpVelocity();
            }
        }

        private void AddJumpVelocity()
        {
            _yDirection += _verticalJumpVelocity;
            _moveDirection += _horizontalJumpVelocity;
        }

        private void ResetJumpCount() =>
            _jumpCount = _jumpCountMax;

        private void ReduceJumpCount() =>
            _jumpCount--;

        private bool CanJump() =>
            _characterController.isGrounded;

        private void SetupJumpVariables()
        {
            _jumpCount = _jumpCountMax;

            _moveDirection = transform.forward.z;
            _gravity = Physics.gravity.y;

            float timeToApex = _maxJumpTime / 1.25f;
            _gravity = -_doubleMultiplier * _maxJumpHeight / Mathf.Pow(timeToApex, _doubleMultiplier);
            _verticalJumpVelocity = _doubleMultiplier * _maxJumpHeight / timeToApex;
        }
    }
}