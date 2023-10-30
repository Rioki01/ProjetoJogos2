using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFuse : MonoBehaviour
{
    [SerializeField]
    private float fuseDelay;
    public GameObject explosionEffectVFX;
    //raio da explosao
    public float radius = 5f;
    public float forceExplosion = 700f;
    //countdown da explosao
    float countdown;
    bool hasExploded = false;
    void Start()
    {
        countdown = fuseDelay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded) 
        {
            Explode();
            //faz isso para não explodir a cada frame.
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffectVFX, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
          Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            //se não for null, ou seja, se tiver rigid body
            if(rb != null)
            {
                rb.AddExplosionForce(forceExplosion, transform.position, radius);
            }
            EnemyStat enemyhp = nearbyObject.GetComponent<EnemyStat>();
            if(enemyhp != null)
            {
                enemyhp.ReceberDano(20);
            }
            Destrutivel destructiblehp = nearbyObject.GetComponent<Destrutivel>();
            if (destructiblehp != null)
            {
                destructiblehp.ReceberDano(20);
            }
        }

        Destroy(gameObject);
    }
}
