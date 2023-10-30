using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
 //Da o efeito de camera lenta quando se leva dano/mata um boss.
 private bool WaitTime;
 public void SlowmoTime(float duracao)
 {
    if(WaitTime)
        return;
    Time.timeScale = 0.2f;
    StartCoroutine(Wait(duracao));

 }  
IEnumerator Wait(float duracao)
{
    WaitTime = true;
    yield return new WaitForSecondsRealtime(duracao);
    Time.timeScale = 1.0f;
    WaitTime = false;
}
}