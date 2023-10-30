using System.Collections.Generic;
using UnityEngine;

public class CameraInterest : MonoBehaviour
{
    // script seta oque a camera deve ou não focar, como players, e bosses.
    // se há na cena, adiciona.
    private void Start()
    {
        CameraManager.Instance.AddTargets(transform);
    }
    //se não, remove.
    private void OnDisable()
    {
        CameraManager.Instance.RemoveTarget(transform);
    }
}
