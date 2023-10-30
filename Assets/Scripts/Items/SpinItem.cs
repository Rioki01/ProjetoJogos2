using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    Vector3 rotateDir = new Vector3();

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * rotateDir * Time.deltaTime);   
    }
}
