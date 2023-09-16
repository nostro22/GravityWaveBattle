using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonUnity : MonoBehaviour
{

    private static SingletonUnity Instance;
    private int valorX;
    private void Awake()
    { 
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static SingletonUnity Instace
    {
        get {return Instance; }       
    }
   /* public void SetValorX(int valor)
    {
        valorX = valor;
    }*/
    public int getValorX()
    {
        return valorX;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
