using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSpawn : MonoBehaviour
{
    // Usado para aumentar a area do teleporter quando ele for ativado.


    public GameObject teleporter;
    private Vector3 scaleChange;
    public bool IsPortalActive = false;
    [SerializeField] public KeyCode teclaPortal = KeyCode.KeypadEnter;

    void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        IsPortalActive = false;
    }

    void Update()
    {
        if (IsPortalActive == true)
        {
            teleporter.transform.localScale += scaleChange;
            if (teleporter.transform.localScale.y < -20f)
            {
                //Para de cresceer
                scaleChange = new Vector3(0f, 0f, 0f);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Players")
        {
            Debug.Log("PlayerInTeleport");
            if (Input.GetKeyDown(teclaPortal) && IsPortalActive == false)
            {
                teleporter.SetActive(true);
                //teleporter = Instantiate(teleporter, transform.position, transform.rotation);
                //faz o teleporter ser uma child.
                //teleporter.transform.parent = gameObject.transform;
                IsPortalActive = true;
            }
        }
    }
}
