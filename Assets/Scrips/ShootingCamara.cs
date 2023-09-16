﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCamara : MonoBehaviour
{
    [SerializeField] private Vector2 EjeRot;
    [SerializeField] private float sensitivity;
    [SerializeField] private Transform refposition;
    [SerializeField] private Transform refPosition2;
    [SerializeField] private float offsetPosition;

    private float auxRotationX;
    private float auxRotationY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EjeRot.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        EjeRot.x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        auxRotationX += EjeRot.x;
        auxRotationY -= EjeRot.y;

        auxRotationY = Mathf.Clamp(auxRotationY, -90, 0);
        auxRotationX = Mathf.Clamp(auxRotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(auxRotationY, auxRotationX, 0);
        transform.position = refposition.position + offsetPosition*(refPosition2.position-refposition.position);


    }
}

