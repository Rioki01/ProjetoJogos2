using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //usa coroutine, logo procurar alternativas melhores!
    //Treme a camera.
    public IEnumerator Shake (float duracao, float forcaShake)
    {
        Vector3 posicaoOriginal = transform.localPosition;
        float tempo = 0.0f;

        while(tempo < duracao)
        {
            float x = Random.Range(-1f, 1f) * forcaShake;
            float y = Random.Range(-1f, 1f) * forcaShake;

            transform.localPosition = new Vector3(x, y, posicaoOriginal.z);
            tempo += Time.deltaTime;
            yield return null;
        }
        transform.localPosition  = posicaoOriginal;
    }
}
