using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripulanteTranquilo : tripulante
{
    private void Start()
    {
        gameObject.GetComponent<Animator>().SetFloat("Dance", danceStyle);
    }
    public override void SetDanceStyle( )
    {
        danceStyle = 0;
    }
    
}