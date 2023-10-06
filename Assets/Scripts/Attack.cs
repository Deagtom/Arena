using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;

    private void Start() => _animator = GetComponent<Animator>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _animator.SetBool("attack", true);
        else if (Input.GetMouseButtonUp(0))
            _animator.SetBool("attack", false);
    }
}