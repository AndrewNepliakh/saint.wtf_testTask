using UnityEngine;

namespace Controllers.PlayerController
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMoveController : MonoBehaviour
    {
        private CharacterController _characterController;
        private float _speed = 10.0f;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var movement = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
            var movementVector = new Vector3(movement.x, 0.0f, movement.y);

            movementVector += Physics.gravity;
            
            _characterController.Move(movementVector * _speed * Time.deltaTime);
        }
    }
}