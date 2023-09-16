using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRB : MonoBehaviour
{

    public bool isOnGround;
    public bool isOnPause;
    protected float velocidadMin =160;
     protected float velocidadNormal=200;
     protected float velocidadMax=250;
     protected float velocidadGiro=3;
     protected float fuezaEsquivar=100;
     protected float backwardPenalty=1;
     protected int fuerzaImpulso=1000;
     protected bool saltar;
     public CamaraController CamaraController;
     public Transform pointSpawnBullet;
     public MotherPool motherPool;
    public Animator myAnimator;
    public bool ILive = true;
     protected float groundedMaxDistance=10;    
    protected float ejeX = 0f;
    protected float movingForward = 0f;
    protected float movingRigth = 0f;
    protected float ejeY;
    protected Rigidbody miController;
    protected Vector3 normal;
    protected float rotateAngle = 100f;
    protected float velocidadBarco = 20;
    protected bool shootPosition;
    protected Vector3 savedInput;
    
    //static Animator _animation;



    // Start is called before the first frame update
  
    public virtual Vector3 GetInput()
    {
        return Vector3.zero;
    }


    public virtual void Move()
    {


    }
    public virtual Quaternion Rotate()
    {
        return Quaternion.identity;
    }
    public virtual void Jump()
    {
     
    }
    public virtual void setGrounded(float distance)
    {
       
    }

    public virtual void SetOnPause( bool paused)
    {
       
    }
    public virtual void setNormalSpeed(float speed)
    {
        velocidadNormal = speed;
    }
}
