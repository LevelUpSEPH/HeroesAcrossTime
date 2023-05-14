using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour // gets destroyed when it collides with something, 
{
    [SerializeField] private float _bulletLifetime = 3f;
    private bool _isPlayerBullet = true;
    private float _bulletSpeedBase = 30f;
    private float _bulletSpeed;
    private float _bulletDamage;

    private void OnEnable(){
        StartCoroutine(BulletLifetime());
        ResetBullet();
    }

    void Update()
    {
        transform.Translate(transform.forward * _bulletSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Player") && !_isPlayerBullet){
            PlayerCharacter playerCharacter = ActiveCharacterController.Instance.GetActivePlayerCharacter(); // bad usage
            playerCharacter.TakeDamage(_bulletDamage);
        }

        else if(other.gameObject.CompareTag("Enemy") && _isPlayerBullet){
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(_bulletDamage);
        }

        gameObject.SetActive(false);
    }

    private IEnumerator BulletLifetime(){
        yield return new WaitForSeconds(_bulletLifetime);
        gameObject.SetActive(false);
    }

    private void SetBulletRotation(Quaternion rotation){
        transform.rotation = rotation;
    }

    private void SetBulletSpeed(float bulletSpeed){
        _bulletSpeed = bulletSpeed;
    }

    private void SetBulletDamage(float damage){
        _bulletDamage = damage;
    }

    private void SetIsPlayerBullet(bool isPlayerBullet){
        _isPlayerBullet = isPlayerBullet;
    }

    public void InitializeBullet(float bulletSpeed, float bulletDamage, bool isPlayerBullet, Quaternion shooterRotation){
        SetBulletSpeed(bulletSpeed);
        SetBulletRotation(shooterRotation);
        SetBulletDamage(bulletDamage);
        SetIsPlayerBullet(isPlayerBullet);
    }

    private void ResetBullet(){
        SetBulletSpeed(_bulletSpeedBase);
        SetBulletDamage(0);
        SetIsPlayerBullet(false);
    }
}
