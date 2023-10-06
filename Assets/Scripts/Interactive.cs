using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _fpcCamera;
    [SerializeField] private float _maxDistanceRay = 15f;
    private Ray _ray;
    private RaycastHit _hit;

    private GameObject _currentGun;
    private GameObject _currentWeapon;

    [SerializeField] private Text _textInteractive;

    [Header("Body")]
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftHand;

    [Header("Keys")]
    [SerializeField] private KeyCode _give;
    [SerializeField] private KeyCode _drop;

    private bool _isTakenGun = false;
    private bool _isTakenWeapon = false;

    private void Start() => _textInteractive.text = string.Empty;

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
        Drop();
    }

    private void Ray() => _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);

        if (_hit.transform == null)
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
    }

    private void Interact()
    {
        if (!PauseMenu.isMenuPaused)
        {
            if (_hit.transform != null && (_hit.transform.tag != "Gun" || _hit.transform.tag != "Weapon"))
                _textInteractive.text = string.Empty;

            if (_hit.transform != null && _hit.transform.tag == "Gun" && !_isTakenGun)
            {
                _textInteractive.text = $"[{_give}] Подобрать";
                if (Input.GetKeyDown(_give))
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.yellow);
                    _currentGun = _hit.transform.gameObject;
                    _currentGun.GetComponent<Rigidbody>().isKinematic = true;
                    _currentGun.GetComponent<Gun>().enabled = true;
                    _currentGun.transform.parent = _rightHand.transform;
                    _currentGun.transform.localPosition = Vector3.zero;
                    _currentGun.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    _isTakenGun = true;
                }
            }

            if (_hit.transform != null && _hit.transform.tag == "Weapon" && !_isTakenWeapon)
            {
                _textInteractive.text = $"[{_give}] Подобрать";
                if (Input.GetKeyDown(_give))
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.yellow);
                    _currentWeapon = _hit.transform.gameObject;
                    _currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                    _currentWeapon.GetComponent<Weapon>().enabled = true;
                    _currentWeapon.transform.parent = _leftHand.transform;
                    _currentWeapon.transform.localPosition = Vector3.zero;
                    _currentWeapon.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    _isTakenWeapon = true;
                }
            }
        }
    }

    private void Drop()
    {
        if (Input.GetKeyDown(_drop) && _isTakenGun)
        {
            _currentGun.GetComponent<Gun>().enabled = false;
            _currentGun.GetComponent<Rigidbody>().isKinematic = false;
            _currentGun.transform.parent = null;
            _currentGun = null;
            _isTakenGun = false;
        }
        if (Input.GetKeyDown(_drop) && _isTakenWeapon)
        {
            _currentWeapon.GetComponent<Weapon>().enabled = false;
            _currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            _currentWeapon.transform.parent = null;
            _currentWeapon = null;
            _isTakenWeapon = false;
        }
    }
}