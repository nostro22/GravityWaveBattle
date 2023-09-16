using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
   
    private Vector3 savedInput;

   [SerializeField] private float velocidadDespzamiento;
   [SerializeField] private float velocidadGiro;  
   [SerializeField] private int gravity;
   [SerializeField] private int fuerzaImpulso;
    private float ejeX = 0f;
    private float ejeZ = 0f;
    private float ejeY;
    [SerializeField] private bool saltar;
    private CharacterController miController;
    

    // Start is called before the first frame update
    void Start()
{
       miController = gameObject.GetComponent<CharacterController>();
        ejeY = 0f;

    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Rotate();        

    }
    private void FixedUpdate()
    {
        SimularGravedad();
        Jump();
    }

    public Vector3 GetInput()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)|| (Input.GetKey(KeyCode.Q))|| (Input.GetKey(KeyCode.E)))
        {

            if (Input.GetKey(KeyCode.W))
            {
                ejeZ = 1;
            }

            else if (Input.GetKey(KeyCode.S))
            {
                ejeZ = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                ejeX = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                ejeX = 1;
            }
            if ((Input.GetKey(KeyCode.Q)))
            {
                ejeY +=  velocidadGiro * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                ejeY -=  velocidadGiro * Time.deltaTime;
            }
            else
            {
                ejeY = 0;
            }
            if(Input.GetKey(KeyCode.Space))
            {
                saltar = true;
            }          
          
        }
        else
        {
            ejeX = 0f;
            ejeZ = 0f;
            ejeY = 0f;
        }
        savedInput = new Vector3(ejeX, ejeY, ejeZ);
        return savedInput;             
    }
    public void Move()
    {
      Vector3 auxMovimiento = new Vector3(savedInput.x,0f,savedInput.z);
        miController.Move(auxMovimiento*velocidadDespzamiento*Time.deltaTime);
    }
    public void Rotate()
    {
        transform.Rotate(0f, savedInput.y , 0f);
    }
    public void Jump()
    {
        if (saltar && miController.isGrounded)
        {
            Vector3 auxSalto = new Vector3(0f, fuerzaImpulso, 0f);
            miController.Move(auxSalto  * Time.fixedDeltaTime);
            
        }
        saltar = false;
    }
    public void SimularGravedad()
    {
        if (miController.isGrounded == false)
        {
            Vector3 auxGravedad = new Vector3(0f, gravity, 0f);
            miController.Move(-auxGravedad * velocidadDespzamiento * Time.fixedDeltaTime);
        }
    }
}
