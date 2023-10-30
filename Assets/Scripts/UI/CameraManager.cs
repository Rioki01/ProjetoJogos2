using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // script para camera seguir o player.

    #region singleton
    public static CameraManager Instance { get; private set;}

    private void Awake()
    {
        //se não há instancias na cena, logo esta é a instancia.
        if(Instance == null)
        {
            Instance = this;
        }
        //se houver, nos destruir, pois só necessitamos de uma camera.
        else if( Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    //Zooms
    [SerializeField] private float minZoomDistance = 10f;
    [SerializeField] private float maxZoomDistance = 40f;
    [SerializeField] private float minDistance = -10f;
    [SerializeField] private float maxDistance = -18f;
    [SerializeField] private float smoothTime = 0.4f;
    [SerializeField] private float minY = 10f;
    [SerializeField] private float maxY = 30f;
    [SerializeField] private float minZ = -12f;
    [SerializeField] private float maxZ = -15f;

    [SerializeField] private List<Transform> targets = new List<Transform>();
    private Vector3 velocidade;

    //Lateupdate pois a camera vai seguir após o update.
    private void LateUpdate()
    {
       if(targets.Count == 0) { return; }
       Move();
       Zoom();
    }

    //Adiciona e Remove pontos de interesse na camera.
    public void AddTargets(Transform newTarget)
    {
        if(!targets.Contains(newTarget))
        {
            targets.Add(newTarget);
        }
    }
    public void RemoveTarget(Transform targetToRemove)
    {
        if(targets.Contains(targetToRemove))
        {
            targets.Remove(targetToRemove);
        }
    }
    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        centerPoint.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, centerPoint, ref velocidade, smoothTime);
    }
    private void Zoom()
    {
        float greatestDistance = GetGreatestDistance();
        //se não for maior é 0.
        if(greatestDistance < minZoomDistance) { greatestDistance = 0f; }

        //calcula e faz o lerp entre a nova distancia, movendo a camera depednendo da distancia dos players.
        float newY = Mathf.Lerp(minY, maxY, greatestDistance / maxZoomDistance);
        float newZ = Mathf.Lerp(minZ, maxZ, greatestDistance / maxDistance);
        //só muda o valor de Y da camera.
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, newY, Time.deltaTime), Mathf.Lerp(transform.position.z, newZ, Time.deltaTime));
    }
    private float GetGreatestDistance()
    {
        Bounds bounds = EncapsulateTargets();

        //retorna a boundary dos players, e checa o tamanho X e Z, e retorna o maior entre os 2.
        return bounds.size.x > bounds.size.z ? bounds.size.x : bounds.size.z;
    }

    private Vector3 GetCenterPoint()
    {
        //se só há um alvo, logo o centro é ele.
        if(targets.Count == 1)
        {
            return targets[0].position;
        }
        //calcula o centro dos alvos.
        Bounds bounds = EncapsulateTargets();
        Vector3 center = bounds.center;
        return center;

    }
    private Bounds EncapsulateTargets()
    {
        //cria uma caixa e calcula o centro
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach(Transform target in targets)
        {
            bounds.Encapsulate(target.position);
        }
        return bounds;
    }

}
