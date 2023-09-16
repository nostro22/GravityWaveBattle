using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRB2 : ControllerRB
{
    void Start()
    {
        miController = gameObject.GetComponent<Rigidbody>();
        ejeY = 0f;
        isOnGround = true;
        // _animation = GetComponent<Animator>();
        normal = Vector3.up;
        isOnPause = false;
        ILive = true;
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Rotate();
    }
    private  void FixedUpdate()
    {
        miController.velocity = transform.forward * velocidadBarco;
        //Jump();   
        Move();
        miController.velocity = transform.forward * velocidadBarco;
    }
    public override Vector3 GetInput()
    {

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && isOnPause==false)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                movingForward = 1;
                // _animation.SetBool("isWalking", true);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movingForward = -1;
                // _animation.SetBool("isWalkingReverse", true);
            }


            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                ejeY = transform.rotation.y - velocidadGiro;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                ejeY = transform.rotation.y + velocidadGiro;
            }
            else
            {
                ejeY = transform.rotation.y;
            }
        }
        else
        {
            movingRigth = 0f;
            movingForward = 0f;
            ejeY = 0f;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && isOnPause == false)
        {
            Debug.Log("Enter Keypad");
            shootPosition = !shootPosition;
            if (shootPosition)
            {
                Debug.Log("Enter shootPosition");
                CamaraController.OpenCameraPj2(3);
            }
            else if (!shootPosition)
            {
                Debug.Log("Enter alabama");
                CamaraController.OpenCameraPj2(2);
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad0) && isOnPause == false)
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
            isOnPause=true;
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
