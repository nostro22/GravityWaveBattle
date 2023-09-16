﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripulanteExcentrico : tripulante
{
    private void Awake()
    {
       
    }
    private void Start()
    {
        gameObject.GetComponent<Animator>().SetFloat("Dance", danceStyle);
    }
    public override void SetDanceStyle()
    {
        danceStyle = 1;
    }
   
}