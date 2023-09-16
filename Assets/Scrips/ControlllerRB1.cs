using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlllerRB1 : ControllerRB
{
    
    void Start()
    {
        miController = gameObject.GetComponent<Rigidbody>();
        ejeY = 0f;
        isOnGround = true;
        isOnPause = false;
        // _animation = GetComponent<Animator>();
        normal = Vector3.up;
        ILive = true;
    }
    // Update is called once per frame
    void Update()
    {

        GetInput();
        Rotate();
    }
    private void FixedUpdate()
    {
        //Jump();   
        Move();
        miController.velocity = transform.forward * velocidadBarco;
    }
    public override Vector3 GetInput()
    {
        if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ))&& isOnPause==false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                movingForward = 1;
                // _animation.SetBool("isWalking", true);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                movingForward = -1;
                // _animation.SetBool("isWalkingReverse", true);
            }
            ///Esto no se usara lo dejo para probar movimiento en el desarrollo

           

            if ((Input.GetKey(KeyCode.A)))
            {
                ejeY = transform.rotation.y - velocidadGiro;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                ejeY = transform.rotation.y + velocidadGiro;
            }
            else
            {
                ejeY = transform.rotation.y;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                //saltar = true;
            }
        }
        else
        {
            movingRigth = 0f;
            movingForward = 0f;
            ejeY = 0f;
            // _animation.SetBool("isWalking",false);
            // _animation.SetBool("isWalkingReverse", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)&& isOnPause==false)
        {
            shootPosition = !shootPosition;
            if (shootPosition)
            {
                CamaraController.OpenCamera(1);
            }
            else if (!shootPosition)
            {
                CamaraController.OpenCamera(0);
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isOnPause == false)
        {
            motherPool.RequestObject(pointSpawnBullet);


        }

        savedInput = new Vector3(movingRigth, ejeY, movingForward);
        return savedInput;
    }


    public override void Move()
    {

        if (movingForward > 0)
        {
            velocidadBarco = velocidadMax;
        }
        else if (movingForward < 0)
        {
            velocidadBarco = velocidadMin;
        }
        else if (movingForward == 0)
        {
            velocidadBarco = velocidadNormal;
        }
        if (movingRigth < 0)
        {
            //miController.AddForce(transform.right * fuezaEsquivar, ForceMode.Impulse);
        }
        else if (movingRigth > 0)
        {
            //miController.AddForce(transform.right * fuezaEsquivar, ForceMode.Impulse);
        }

    }
    public override Quaternion Rotate()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, savedInput.y * velocidadGiro, 0);
        return deltaRotation;
        //Quaternion deltaRotation = Quaternion.Euler(transform.rotation.x, savedInput.y * velocidadGiro * Time.fixedDeltaTime, transform.rotation.z);
        //transform.rotation = miController.rotation * deltaRotation;
    }
    public override void Jump()
    {
        if (saltar && isOnGround)
        {
            Vector3 auxSalto = new Vector3(0f, fuerzaImpulso, 0f);
            miController.AddForce(auxSalto * Time.fixedDeltaTime, ForceMode.Impulse);
            //_animation.SetTrigger("Jump");           
        }
    }
    public override void setGrounded(float distance)
    {
        if (distance < groundedMaxDistance)
        {
            isOnGround = true;
            saltar = false;
        }
        else
        {
            isOnGround = false;
        }
    }

    public override void SetOnPause(bool paused)
    {
        isOnPause = paused;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Balas") || collision.gameObject.layer == LayerMask.NameToLayer("Pillars"))
        {

            isOnPause = true;
            velocidadNormal = 0;
            ILive = false;
            myAnimator.SetBool("isDead", true);
        }
    }

    public override void setNormalSpeed(float speed)
    {
        velocidadNormal = speed;
    }

}
