using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class camaraScript : MonoBehaviour
{

    [SerializeField] private Transform miTraget;
    [SerializeField] private float offSet;
    [SerializeField] private Vector3 camaraSet;
    [SerializeField] private float smoothTime;
    [SerializeField] private Quaternion rotationOffSet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp( gameObject.transform.position, miTraget.position+ camaraSet + gameObject.transform.forward* offSet, smoothTime*Time.deltaTime);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, miTraget.rotation*rotationOffSet, smoothTime * Time.deltaTime);
    }
}
