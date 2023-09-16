using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherPool : MonoBehaviour
{
    [SerializeField] private BolaCanonScript poolObject;
    [SerializeField] private int poolSize;
    [SerializeField] private Vector3 cementerio;
    [SerializeField] private GravitySimulator gravitySimulator;
    [SerializeField] private BolaCanonScript[] myPool;
    void Awake()
    {
        InstanciarPool();
    }
    // Start is called before the first frame update
    void Start()//las clases/metodos/variables staticas siempres se acceden o usan a partir del start , sino traen conflictos 
    {
        //SingletonUnity.Instace.SetValorX(7);
       //Debug.Log( SingletonUnity.Instace.getValorX());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void InstanciarPool()
    {
        //Inicializar Pool
        myPool = new BolaCanonScript[poolSize];
        cementerio = new Vector3 (000, 100, 000);
        for (int i = 0; i < poolSize; i++)
        {                 
            myPool[i] = Instantiate(poolObject);
            myPool[i].setCementerio(cementerio);
            myPool[i].transform.position = cementerio;
            myPool[i].gameObject.SetActive(false);
        }
    }
  public GameObject RequestObject(Transform pos)
  {

        for (int i = 0; i < myPool.Length; i++)
        {
            if (myPool[i].gameObject.activeInHierarchy==false)
            {
                myPool[i].transform.position = pos.position;
                myPool[i].transform.rotation = pos.rotation;
                myPool[i].auxFakeGravity = gravitySimulator.GetFakeGravity();
                myPool[i].gameObject.SetActive(true);
                return myPool[i].gameObject;
            }
            else if (myPool[myPool.Length-1].gameObject.activeInHierarchy ==true)
            {
                Debug.Log("todos los objetos estan instanciados aumente el tamaño del pool o regule el flujo de activacion");
                return null;
            }
        }
        return null;
  }
   
}
