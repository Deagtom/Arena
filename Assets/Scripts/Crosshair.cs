using UnityEngine;
using UnityEngine.UIElements;

public class Crosshair : MonoBehaviour
{
    [Header("Crosshair")]
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private float _sizeState;
    [SerializeField] private float _sizeMove;
    [SerializeField] private float _sizeCurrent;
    [SerializeField] private float _speedSize;

    private bool _IsMoving { get { if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) { return true; } else { return false; } } }

    private void Update()
    {
        _sizeCurrent = _IsMoving ? Mathf.Lerp(_sizeCurrent, _sizeMove, Time.deltaTime * _speedSize) : Mathf.Lerp(_sizeCurrent, _sizeState, Time.deltaTime * _speedSize);
        crosshair.sizeDelta = new Vector2(_sizeCurrent, _sizeCurrent);
    }
}