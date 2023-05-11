using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletPool = new List<GameObject>();

    private void Start(){
        foreach(Transform child in transform){
            GameObject bulletBehaviour = child.gameObject;
            _bulletPool.Add(bulletBehaviour);
        }
    }

    public GameObject GetBulletToShoot(){
        foreach (GameObject bullet in _bulletPool)
        {
            if(!bullet.gameObject.activeInHierarchy){
                return bullet;
            }
                

        }
        Debug.LogError("Not enough bullets exist in pool, instantiating 3 more");
        for(int i = 0; i < 3; i++)
            Instantiate(_bulletPool[0], transform);
        return null;
    }
}
