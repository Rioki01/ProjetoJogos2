using System.Collections.Generic;
using UnityEngine;

public class CameraInterest : MonoBehaviour
{
    // script seta oque a camera deve ou n�o focar, como players, e bosses.
    // se h� na cena, adiciona.
    private void Start()
    {
        CameraManager.Instance.AddTargets(transform);
    }
    //se n�o, remove.
    private void OnDisable()
    {
        CameraManager.Instance.RemoveTarget(transform);
    }
}
