using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemCreate : MonoBehaviour
{
    // Start is called before the first frame update
    private float tempoSpawn = 1f;

    void Start()
    {
        removeColliders();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoSpawn > 0)
        {
            tempoSpawn -= Time.deltaTime;
        } 
        else
        {
            addColliders();
        }
    }

    void removeColliders()
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }
    }
    void addColliders()
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
    }
}
