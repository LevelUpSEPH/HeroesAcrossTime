using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour // gets destroyed when it collides with something, 
{
    [SerializeField] private float _bulletLifetime = 3f;
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
        Debug.Log(other.gameObject.name);
        
        if(other.gameObject.CompareTag("Player")){
            // damage the player
        }

        else if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Collided with enemy");
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

    public void InitializeBullet(float bulletSpeed, float bulletDamage, Quaternion shooterRotation){
        SetBulletSpeed(bulletSpeed);
        SetBulletRotation(shooterRotation);
        SetBulletDamage(bulletDamage);
    }

    private void ResetBullet(){
        SetBulletSpeed(_bulletSpeedBase);
        SetBulletDamage(0);
    }
}
