using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _menuPaused;
    [SerializeField] private GameObject _crosshair;

    public static bool isMenuPaused = false;

    private void Start() => _menuPaused.SetActive(false);

    private void Update() => ActiveMenu();

    private void ActiveMenu()
    {
        isMenuPaused = Input.GetKeyDown(KeyCode.Escape) ? !isMenuPaused : isMenuPaused;

        if (isMenuPaused)
        {
            Time.timeScale = 0f;
            _menuPaused.SetActive(true);
            _crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            _menuPaused.SetActive(false);
            _crosshair.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Continue() =>  isMenuPaused = false;

    public void Settings() => Debug.Log("Натсройки");

    public void Close() => Application.Quit();
}