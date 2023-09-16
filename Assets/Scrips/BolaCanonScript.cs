using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanonScript : MonoBehaviour
{
    [SerializeField] float speedCanonBall=50;    
    public Vector3 auxFakeGravity;
    [SerializeField] Transform origenPosition;
    [SerializeField] int bounces;
    [SerializeField] float lifeTime;
    private Vector3 canonForce;
    private float defaultTimer;
    private int defaultBounces;
    [SerializeField] private Vector3 cementerioRef;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource burnSound;
    // Start is called before the first frame update

    private void Awake()
    {
        defaultTimer = lifeTime;
        defaultBounces = bounces;
       
    }
    private void OnEnable()
    {
        Inicialice();
        transform.GetComponent<Rigidbody>().AddForce(canonForce,ForceMode.Impulse);
        shootSound.Play();
        burnSound.Play();
    }

    public void GravityBall( Vector3 directionGravity)
    {
        transform.GetComponent<Rigidbody>().AddForce(directionGravity/100, ForceMode.Acceleration);
    }
    public void setCementerio(Vector3 referencia)
    {
        transform.position = referencia;
    }

    public void Inicialice()
    {
        canonForce = transform.forward * speedCanonBall;
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        lifeTime = defaultTimer;
        bounces = defaultBounces;
    }

    public void ImpulseCanonBall()
    {
        if (canonForce.magnitude>0)
        {
            canonForce = canonForce - canonForce.normalized * Time.deltaTime;
        }
        else
        {
            canonForce = Vector3.zero;
        }    
    }
    // Update is called once per frame
    void Update()
    {
        autoInactive();   
    }

    private void FixedUpdate()
    {
        ImpulseCanonBall();
        GravityBall(auxFakeGravity);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        bounces -= 1;

        if (bounces <= 0)
        {
            transform.position = cementerioRef;
            gameObject.SetActive(false);
        }
    }

    public void autoInactive()
    {     
        if (lifeTime > 0)
        {
            lifeTime = lifeTime- Time.deltaTime;
        }
        if (lifeTime <= 0)
        {
            Debug.Log("se me acabo el tiempo y me desactive");
            transform.position = cementerioRef;   
            gameObject.SetActive(false);
        }
    }


}
