using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedItemsPrefabs : MonoBehaviour
{
    // Script para mostrar items nos players, quando forem coletados!


    //Gasoline Prefab!
    [SerializeField] public GameObject gasolinePrefab;
    //MedicKit Prefab!
    [SerializeField] public GameObject medicKitPrefab;
    //Adrenaline Prefab!
    [SerializeField] public GameObject adrenalinePrefab;
    //Boots...?
    //Dinamite Prefab!
    [SerializeField] public GameObject dinamitePrefab;
    //IceTray Prefab!
    [SerializeField] public GameObject iceTrayPrefab;
    //Drone Prefab!
    [SerializeField] public GameObject dronePrefab;
    //Drone Prefab!
    [SerializeField] public GameObject robotArmPrefab;


    void Start()
    {
        HideAllItems();
    }
    private void HideAllItems()
    {
        //white
        gasolinePrefab.SetActive(false);
        adrenalinePrefab.SetActive(false);
        //green
        medicKitPrefab.SetActive(false);
        iceTrayPrefab.SetActive(false);
        //red
        dinamitePrefab.SetActive(false);
        dronePrefab.SetActive(false);
        robotArmPrefab.SetActive(false);
    }

    public void ShowGasolineItem()
    {
        gasolinePrefab.SetActive(true);
    }
    public void ShowMedickitItem()
    {
        medicKitPrefab.SetActive(true);
    }
    public void ShowAdrenalineItem()
    {
        adrenalinePrefab.SetActive(true);
    }
    public void ShowDinamiteItem()
    {
        dinamitePrefab.SetActive(true);
    }
    public void ShowIceItem()
    {
        iceTrayPrefab.SetActive(true);
    }
    public void ShowDroneItem()
    {
        dronePrefab.SetActive(true);
    }
    public void ShowRobotArmItem()
    {
        robotArmPrefab.SetActive(true);
    }


}
