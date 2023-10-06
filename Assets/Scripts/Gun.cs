using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _spawnPoint;
    [Range(20, 100)] [SerializeField] private float _shootForce;
    private float _spread;

    private bool _IsMoving { get { if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) { return true; } else { return false; } } }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !PauseMenu.isMenuPaused)
            Shoot();

        if (_IsMoving && _spread <= 3.0f)
            _spread += Time.deltaTime;
        else if (!_IsMoving && _spread >= 0.0f)
            _spread -= Time.deltaTime * 2.0f;
    }

    private void Shoot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - _spawnPoint.position;

        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * _shootForce, ForceMode.Impulse);
    }
}