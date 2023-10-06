using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player")]
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private GameObject _hand;
    private CharacterController _characterController;
    private Vector3 _position;
    private const float _Gravity = 0.1f;

    [Header("Camera")]
    [SerializeField] private float _sensitivityMouse = 5.0f;
    [SerializeField] private float _smoothTime = 1.0f;
    [SerializeField] private Camera _camera;
    private float _mouseRotationX;
    private float _mouseRotationY;
    private float _mouseRotationCurrentX;
    private float _mouseRotationCurrentY;
    private float _mouseCurrentVelosityX;
    private float _mouseCurrentVelosityY;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        MouseRotation();
    }

    private void PlayerMove()
    {
        if (_characterController.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(horizontal, 0.0f, vertical);
            _position = transform.TransformDirection(move);
        }
        _position.y -= _Gravity;
        _characterController.Move(_position * _speed * Time.fixedDeltaTime);
    }

    private void MouseRotation()
    {
        if (!PauseMenu.isMenuPaused)
        {
            _mouseRotationX += Input.GetAxis("Mouse X") * _sensitivityMouse;
            _mouseRotationY += Input.GetAxis("Mouse Y") * _sensitivityMouse;
            _mouseRotationY = Mathf.Clamp(_mouseRotationY, -30.0f, 15.0f);

            _mouseRotationCurrentX = Mathf.SmoothDamp(_mouseRotationX, _mouseRotationCurrentX, ref _mouseCurrentVelosityX, _smoothTime);
            _mouseRotationCurrentY = Mathf.SmoothDamp(_mouseRotationY, _mouseRotationCurrentY, ref _mouseCurrentVelosityY, _smoothTime);

            _characterController.transform.rotation = Quaternion.Euler(0.0f, _mouseRotationCurrentX, 0.0f);
            _camera.transform.rotation = Quaternion.Euler(-_mouseRotationCurrentY, _mouseRotationCurrentX, 0.0f);
            _hand.transform.rotation = Quaternion.Euler(-_mouseRotationCurrentY, _mouseRotationCurrentX, 0.0f);
        }
    }
}