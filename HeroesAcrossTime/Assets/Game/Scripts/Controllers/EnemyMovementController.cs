using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent _enemyAgent;
    private EnemyAnimatorController _enemyAnimator;
    void Start()
    {
        Initialize();
    }

    private void Initialize(){
        _enemyAgent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<EnemyAnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyAgent.isStopped)
            _enemyAnimator.StopMovingAnimation();
        else
            _enemyAnimator.PlayMovingAnimation();
    }

    public void SetDestination(Vector3 pos){
        _enemyAgent.SetDestination(pos);
    }

    public void SetNavIsStopped(bool isStopped){
        _enemyAgent.isStopped = isStopped;
    }
}
