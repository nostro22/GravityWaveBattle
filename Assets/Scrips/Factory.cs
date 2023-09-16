using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tripulantes
{
    Fuego,
    Heal,
    Count
}


public class Factory : MonoBehaviour
{
    private static Factory Instance;
    private tripulantes invocarMago;
    [SerializeField] Transform[] spawPosition;
    [SerializeField] GameObject parentRef;
    [SerializeField] GameObject prefabMage;
    [SerializeField] Material tripulanteTranquilo;
    [SerializeField] Material tripulanteExcentrico;
    private int randomTripulantes;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0; i < spawPosition.Length; i++)
        {
            randomTripulantes =Random.Range( 0,  2);            
            GetMago(spawPosition[i]);
        }
        
    }
    public static Factory Instace
    {
        get { return Instance; }
    }
    public void GetMago(Transform spawPlace)
    {
        GameObject tripulanteElegido;
        tripulanteElegido =Instantiate(prefabMage);        
        tripulanteElegido.transform.position = spawPlace.position;
        tripulanteElegido.transform.rotation = spawPlace.rotation;
        tripulanteElegido.transform.parent = parentRef.transform;

        switch ((tripulantes)randomTripulantes)
        {
            case tripulantes.Fuego:
                tripulanteElegido.AddComponent<tripulanteExcentrico>();
                tripulanteElegido.GetComponent<tripulanteExcentrico>().SetDanceStyle();
                tripulanteElegido.GetComponentInChildren<Renderer>().material = tripulanteTranquilo;
                break;
            case tripulantes.Heal:
                tripulanteElegido.AddComponent<tripulanteTranquilo>();
                tripulanteElegido.GetComponent<tripulanteTranquilo>().SetDanceStyle();
                tripulanteElegido.GetComponentInChildren<Renderer>().material = tripulanteExcentrico;
                break;
            case tripulantes.Count:
                break;
            default:
                break;
        }
    }
   
}