using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BillboardCam : MonoBehaviour
{
    //move a barra de vida para a camera.
    private Camera cam;

    void Start()
    {
        //Seta a camera p
        cam = Camera.main;
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
