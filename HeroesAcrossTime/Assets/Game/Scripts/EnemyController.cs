using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private GameObject _enemyModel;
    [SerializeField] private GameObject _enemyRagdoll;
    private EnemyMovementController _enemyMovementController;
    private Transform _playerTransform;
    private bool _canSeePlayer = false;
    private bool _isDead = false;
    private float _shootingInterval = 2f;
    private bool _canShoot = true;
    
    private void Awake(){
        _enemyMovementController = GetComponent<EnemyMovementController>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(_isDead)
            return;
        if(!_canSeePlayer){
            _enemyMovementController.SetNavIsStopped(false);
            _enemyMovementController.SetDestination(_playerTransform.position);
        }
        else{
            _enemyMovementController.SetNavIsStopped(true);
            if(_canShoot)
                ShootAtPlayer();
        }
            
            
    }

    private IEnumerator CheckIfCanSeePlayer(){
        while(true){
            Vector3 dirToPlayer = _playerTransform.position - transform.position;
            if(Physics.Raycast(transform.position, dirToPlayer, out RaycastHit raycastHit, 15f)){
                if(raycastHit.collider.CompareTag("Player"))
                    _canSeePlayer = true;
                else
                    _canSeePlayer = false;

            }
        
        }
    }

    public void TakeDamage(float damage){
        if(_isDead)
            return;

        _health -= damage;

        if(_health <= -20f){
            OverkillDie();
        }

        else if(_health <= 0f){
            Die();
        }
    }

    private void Die(){
        _isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        _enemyModel.SetActive(false);
        _enemyRagdoll.SetActive(true);
    }

    private void OverkillDie(){
        _isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        _enemyModel.SetActive(false);
        // play explosion/evaporation particle
    }

    private void ShootAtPlayer(){
        // shoot
        StartCoroutine(ShootingInterval());
    }

    private IEnumerator ShootingInterval(){
        _canShoot = false;
        yield return new WaitForSeconds(_shootingInterval);
        _canShoot = true;
    }

}
