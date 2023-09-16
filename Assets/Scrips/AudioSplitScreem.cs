using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSplitScreem : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    private Transform origen;
    [SerializeField] private Transform AudioListenerPosition;
    private float DistancePj1;
    private float DistancePj2;
    private float distanceToAudioListener;
    private GameObject[] temporal;
    // Start is called before the first frame update
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player2 = GameObject.FindGameObjectWithTag("player2").GetComponent<Transform>();
        AudioListenerPosition = GameObject.FindGameObjectWithTag("audioListener").GetComponent<Transform>();
        origen = transform;
    }

    
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player1.position,origen.position) < Vector3.Distance(player2.position, origen.position))
        {
            distanceToAudioListener = Vector3.Distance(player1.position, origen.position);
            transform.position = Vector3.Lerp(transform.position,AudioListenerPosition.position + player1.position - origen.position,0.01f*Time.deltaTime);
        }
        else
        {
            distanceToAudioListener = Vector3.Distance(player2.position, origen.position);
            transform.position = Vector3.Lerp(transform.position,AudioListenerPosition.position + player2.position - origen.position,0.01f*Time.deltaTime);
        }
        
    }
}
