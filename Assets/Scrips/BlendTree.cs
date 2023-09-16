using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTree : MonoBehaviour
{


    static Animator _animation;
    public float danceTime;
    private float defaultTime;
    private float style;




    // Start is called before the first frame update
    void Start()
    {
        defaultTime = danceTime;
        _animation = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (style == 0 && danceTime >= 0)
        {
            _animation.SetFloat("Dance", 0f);
            
        }
        else if (style == 0.5f && danceTime >= 0)
        {
            _animation.SetFloat("Dance", 0.5f);
            
        }
        else if (style == 1f && danceTime >= 0)
        {
            _animation.SetFloat("Dance", 1f);
           
        }
        if (danceTime <= 0)
        {
            danceTime = defaultTime;
            ChangeStyle();
        }
        danceTime -= Time.deltaTime;

    }


    public void ChangeStyle()
    {
        if(style==0)
        {
            style = 0.5f;
        }
       else if (style == 0.5f)
        {
            style = 1f;
        }
       else if (style == 1)
        {
            style = 0f;
        }
    }
}
   
      
         
        
