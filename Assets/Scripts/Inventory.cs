using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private Image[] _guns;
    [SerializeField] private Image[] _weapons;

    private Gun _currentGun;
    private Weapon _currentWeapon;

    [Header("Body")]
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private GameObject _leftHand;

    private void Update()
    {
        _currentGun = _rightHand.GetComponentInChildren<Gun>();
        _weapons[0].sprite = _currentGun.GetComponentInChildren<Sprite>();
    }
}