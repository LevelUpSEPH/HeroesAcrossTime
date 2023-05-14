/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour
{

    private List<EnemyController> _enemiesInBeam = new List<EnemyController>();

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();
            _enemiesInBeam.Add(enemyController);
        }

    }

    private void OnDisable(){
        ClearEnemiesInBeam();
    }

    public void ClearEnemiesInBeam(){
        _enemiesInBeam.Clear();
    }
}
*/