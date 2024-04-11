using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _distanceToStop;

    private NavMeshAgent _navMeshAgent;
    
    private bool _isAttacking = false;
    
    private Transform _playerTransform;

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (_isAttacking) return;

        if (Vector3.Distance(_playerTransform.position, transform.position) <= _distanceToStop)
        {
            Attack();
        }
        else
        {
            _navMeshAgent.SetDestination(_playerTransform.position);
            _navMeshAgent.isStopped = false;
        }
    }

    private void Attack()
    {
        _navMeshAgent.isStopped = true;
        _isAttacking = true;
        var lastPosition = transform.position;
        
        Sequence attackSequence = DOTween.Sequence();
        attackSequence.Append(transform.DOMove(_playerTransform.position, .5f));
        attackSequence.Append(transform.DOMove(lastPosition, .5f).OnComplete(delegate { _isAttacking = false; }));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player) == false) return;
        
        FindObjectOfType<HeartDisplay>().TakeDamage();
    }
}
