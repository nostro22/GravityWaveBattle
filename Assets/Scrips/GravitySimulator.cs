using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySimulator : MonoBehaviour
{
    /// Raycast parametre

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    public GameObject currentHitObject;
    private Vector3 direction;
    private Vector3 origin;
    private float currentHitDistance;
    [SerializeField] public ControllerRB rbScript;
    [SerializeField] private int playerNumber;

    private RaycastHit hit;
    private Quaternion inputRotation;


    ///Parametros de Gravedad Personal
    
    public float falseGravity = -15f;


    public Vector3 normalRelative;

    private void Awake()
    {
      
       
    }

    void Start()
    {
        
    }

    void Update()
    {
        inputRotation = rbScript.Rotate();
    }

    private void FixedUpdate()
    {

        transform.GetComponent<Rigidbody>().AddForce(Vector3.up*falseGravity,ForceMode.Acceleration);

        origin = transform.position;
        direction = transform.position - transform.up.normalized*2;
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
                if (rbScript.isOnGround)
                {
                    normalRelative = hit.normal;
                    currentHitObject = hit.transform.gameObject;
                    currentHitDistance = hit.distance;
                }
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }

        rbScript.setGrounded(hit.distance);
        FakeGravity();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin,direction*maxDistance);
    }

    private void FakeGravity()
    { 

        Vector3 bodyUp = transform.up;
        transform.GetComponent<Rigidbody>().AddForce(normalRelative * falseGravity,ForceMode.Acceleration);
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, normalRelative) * transform.rotation*inputRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 6* Time.fixedDeltaTime);
    }

    public Vector3 GetFakeGravity()
    {
        return normalRelative * falseGravity;
    }

}
