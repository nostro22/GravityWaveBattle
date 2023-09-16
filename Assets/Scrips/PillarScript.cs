using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PillarScript : MonoBehaviour
{

    [SerializeField] private float pillarMovingDistance;
    [SerializeField] private float distanceMin;
    [SerializeField] private float distanceMax;
    [SerializeField] private float numeroRandom;
    [SerializeField] private float smoothPillar;
    [SerializeField] private float PillarPorcentage=10;
    private Vector3 direccionNormal;
    [SerializeField] private bool active;
    private Rigidbody miBody;
    private Vector3 auxPosition;
    private bool ballHit;

    void Start()
    {
        active = true;
        direccionNormal = -(transform.position - Vector3.zero).normalized;
        miBody = gameObject.GetComponent<Rigidbody>();
        pillarMovingDistance = Random.Range(distanceMin, distanceMax);
        numeroRandom = Random.Range(0, 100);
        auxPosition = miBody.transform.position + direccionNormal * pillarMovingDistance;
        //BatleFieldGenerator();  
    }

    private void Update()
    {
        BatleFieldGenerator();
        if (ballHit)
        {
            MovePillar();
        }        
    }

    private void MovePillar()
    {
            miBody.transform.position = Vector3.Lerp(miBody.transform.position,auxPosition , 1 * Time.deltaTime);     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (active && collision.gameObject.layer == LayerMask.NameToLayer("Balas"))
        {
           
                ballHit = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void BatleFieldGenerator()
    {
        if(numeroRandom<PillarPorcentage)
        {
            active = false;
            MovePillar();
        }
    }
}
