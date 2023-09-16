using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MenuSpash : MonoBehaviour
{
    public MotherPool motherPool;
    [SerializeField] private float shootTimer;
    private float defaultTime;

    // Start is called before the first frame update
    void Start()
    {
        defaultTime = shootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer<0)
        {
            motherPool.RequestObject(transform);
            shootTimer = defaultTime;
        }
        shootTimer -= Time.deltaTime;
    }
}
