using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeController : MonoBehaviour
{
    public static GameTimeController Instance {get; private set;}

    private void Awake(){
        if(Instance != null){
            Destroy(Instance);
        }
        Instance = this;
    }

    public void EnterSlowMotion(){
        Time.timeScale = 0.4f;
        Time.fixedDeltaTime = 0.08f;
    }

    public void ExitSlowMotion(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;
    }
}
