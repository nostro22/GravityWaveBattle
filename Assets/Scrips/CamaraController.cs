using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{

    [SerializeField] private GameObject[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        OpenCamera(0);
        OpenCameraPj2(2);        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCamera(int index)
    {
        for ( int i = 0; i < 2; i++)
        {
            cameras[i].GetComponent<Camera>().enabled=false;

            if(i==index)
            {
                cameras[i].GetComponent<Camera>().enabled = true;
            }
        }
    }
    public void OpenCameraPj2(int index)
    {
        for (int i = 2; i < 4; i++)
        {
            cameras[i].GetComponent<Camera>().enabled = false;

            if (i == index)
            {
                cameras[i].GetComponent<Camera>().enabled = true;
            }
        }
    }
}
