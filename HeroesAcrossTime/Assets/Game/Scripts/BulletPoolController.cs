using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{
    private List<BulletBehaviour> _bulletPool = new List<BulletBehaviour>();

    private void Start(){
        foreach(Transform child in transform){
            BulletBehaviour bulletBehaviour = child.GetComponent<BulletBehaviour>();
            _bulletPool.Add(bulletBehaviour);
        }
    }

    public BulletBehaviour GetBulletToShoot(){
        foreach (BulletBehaviour bullet in _bulletPool)
        {
            if(!bullet.gameObject.activeInHierarchy)
                return bullet;

        }
        Debug.Log("Not enough bullets exist in pool");
        return null;
    }
}
