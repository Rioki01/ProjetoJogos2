using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//REFAZER!
public class TeleporterUI : MonoBehaviour
{
    public GameObject TeleporterArea = null;
    [SerializeField]
    private MapArea mapArea;

    [SerializeField] private Image ProgressImage;

    private void Start()
    {
        Show();
        
    }
    private void Update()
    {
        if (TeleporterArea == null)
        {
            foreach (Transform child in transform)
            {
                TeleporterArea = GameObject.FindGameObjectWithTag("PortalArea");
            }
            if(TeleporterArea != null)
            {
                foreach (Transform child in transform)
                {
                    mapArea = child.GetComponent<MapArea>();
                }
            }
        }
        ProgressImage.fillAmount = mapArea.GetProgress();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
