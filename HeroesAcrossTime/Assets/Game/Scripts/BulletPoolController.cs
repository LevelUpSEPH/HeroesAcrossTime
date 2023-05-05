using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{
    public static BulletPoolController Instance {get; private set;}
    private List<GameObject> _bulletPool = new List<GameObject>();

    public GameObject GetBulletToShoot(){
        foreach (GameObject bullet in _bulletPool)
        {
            if(!bullet.activeInHierarchy)
                return bullet;

        }
    }
}
