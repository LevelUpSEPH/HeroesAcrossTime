using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent _enemyAgent;
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Vector3 pos){
        _enemyAgent.SetDestination(pos);
    }

    public void SetNavIsStopped(bool isStopped){
        _enemyAgent.isStopped = isStopped;
    }
}
