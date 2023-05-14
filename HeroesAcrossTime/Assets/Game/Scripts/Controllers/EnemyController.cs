using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float _health = 100f;
    [SerializeField] private GameObject _enemyModel;
    [SerializeField] private GameObject _enemyRagdoll;
    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] EnemyHealthbar _enemyHealthbar; 
    [SerializeField] private BulletPoolController _bulletPoolController;
    [SerializeField] private Transform _enemyShootingTransform;
    [SerializeField] private float _shootingInterval = 2f;
    [SerializeField] private float _maxRange = 20f;
    private EnemyMovementController _enemyMovementController;
    private Transform _playerTransform;
    private bool _canSeePlayer = false;
    private bool _isDead = false;
    private bool _canShoot = true;
    
    private void Awake(){
        _enemyMovementController = GetComponent<EnemyMovementController>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    
    }

    private void OnEnable(){
        StartCoroutine(CheckIfCanSeePlayer());
    }

    void Update()
    {
        if(_isDead)
            return;

        if(CheckIfTooFar())
            return;

        if(!_canSeePlayer){
            _enemyMovementController.SetNavIsStopped(false);
            _enemyMovementController.SetDestination(_playerTransform.position);
        }
        else{
            _enemyMovementController.SetNavIsStopped(true);
            transform.LookAt(_playerTransform);
            if(_canShoot){
                ShootAtPlayer();
            }
                
        }
            
            
    }

    private bool CheckIfTooFar(){
        return Vector3.Distance(transform.position, _playerTransform.position) > _maxRange;
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
            yield return null;
        }
    }

    public void TakeDamage(float damage){
        if(_isDead)
            return;

        _health -= damage;
        _enemyHealthbar.UpdateHealthBar(_health);

        if(_health <= -35f){
            OverkillDie();
        }

        else if(_health <= 0f){
            Die();
        }
    }

    private void Die(){
        _isDead = true;
        _enemyMovementController.SetNavIsStopped(true);
        GetComponent<CapsuleCollider>().enabled = false;
        _enemyModel.SetActive(false);
        _enemyRagdoll.SetActive(true);
    }

    private void OverkillDie(){
        _isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        _enemyModel.SetActive(false);
        _deathParticle.Play();        
    }

    private void ShootAtPlayer(){
        GameObject bullet = _bulletPoolController.GetBulletToShoot();
        bullet.SetActive(true);
        bullet.transform.position = _enemyShootingTransform.position;
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.InitializeBullet(25f, 20f, false, transform.rotation);

        StartCoroutine(ShootingInterval());
    }

    private IEnumerator ShootingInterval(){
        _canShoot = false;
        yield return new WaitForSeconds(_shootingInterval);
        _canShoot = true;
    }

    public float GetHealth(){
        return _health;
    }

}
