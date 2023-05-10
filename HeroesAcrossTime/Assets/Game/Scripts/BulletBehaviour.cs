using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour // gets destroyed when it collides with something, 
{
    [SerializeField] private float _bulletLifetime = 3f;
    private float _bulletSpeedBase = 30f;
    private float _bulletSpeed;

    private void OnEnable(){
        StartCoroutine(BulletLifetime());
        ResetBullet();
    }

    void Update()
    {
        transform.Translate(transform.forward * _bulletSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            // damage the player
        }

        else if(other.gameObject.CompareTag("Enemy")){
            Debug.Log("Collided with enemy");
            // damage the enemy
        }

        gameObject.SetActive(false);
    }

    private IEnumerator BulletLifetime(){
        yield return new WaitForSeconds(_bulletLifetime);
        gameObject.SetActive(false);
    }

    public void SetBulletRotation(Quaternion rotation){
        transform.rotation = rotation;
    }

    public void SetBulletSpeed(float bulletSpeed){
        _bulletSpeed = bulletSpeed;
    }

    public void InitializeBullet(float bulletSpeed, Quaternion shooterRotation){
        SetBulletSpeed(bulletSpeed);
        SetBulletRotation(shooterRotation);
    }

    private void ResetBullet(){
        SetBulletSpeed(_bulletSpeedBase);
    }
}
