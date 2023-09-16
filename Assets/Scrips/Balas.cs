using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    [SerializeField] private float lifeTime;
   [SerializeField] private Vector3 cementerioRef;    
    private float defaultTimer;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        defaultTimer = lifeTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        autoInactive();
        MovimientoBala();
    }
    public void autoInactive()
    {
       if(isActiveAndEnabled && lifeTime<0)
        {
            lifeTime = defaultTimer;
                      
        }
       if(lifeTime>0)
        {
            lifeTime -= Time.deltaTime;           
        }
       if(lifeTime<=0)
        {
            transform.position = cementerioRef;
            gameObject.SetActive(false);
        }
    }

    public void MovimientoBala()
    {
        transform.position = transform.forward * Time.deltaTime;
    }
    public void setCementerio(Vector3 referencia)
    {
        cementerioRef = referencia;
    }
}
