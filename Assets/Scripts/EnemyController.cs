using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float _speedEnemy;
    [SerializeField] private float _chaseRange;
    [SerializeField] private NavMeshAgent _agent;
    private Transform _target;

    private void Start() => _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    private void FixedUpdate()
    {
        float distance = Vector3.Distance(_agent.transform.position, _target.position);
        if (distance < _chaseRange)
            _agent.SetDestination(_target.position);
    }
}