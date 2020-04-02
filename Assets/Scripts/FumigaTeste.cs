using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumigaTeste : MonoBehaviour
{
    public GameObject center, buraco;
    public float vel;
    public bool _return;
    public Vector3 movimento;
    public float distance_center, distance_buraco;
    public bool torreAfrente;

    CharacterController CC;

    // Start is called before the first frame update
    void Start()
    {
        _return = false;
        CC = GetComponent<CharacterController>();
        torreAfrente = false; 
    }

    // Update is called once per frame
    void Update()
    {

        distance_center = Vector3.Distance(transform.position, center.transform.position);
        distance_buraco = Vector3.Distance(transform.position, buraco.transform.position);


        if (distance_center <= 1)
        {

            _return = true;
        }


        if(_return == false)
        {

            if(torreAfrente == true)
            {
                movimento.z = 0;
                movimento.x = vel * Time.deltaTime;
                  torreAfrente = false;
            }
            else
            {
                transform.LookAt(center.transform.position);
                movimento.x = 0;
                movimento.y = -4 * Time.deltaTime;
                movimento.z = vel * Time.deltaTime;
            }

            movimento = transform.TransformDirection(movimento);
            CC.Move(movimento);
        }
        else if(_return == true)
        {
            transform.LookAt(buraco.transform.position);

            movimento.x = 0;
            movimento.y = -4 * Time.deltaTime;
            movimento.z = vel * Time.deltaTime;

            movimento = transform.TransformDirection(movimento);
            CC.Move(movimento);

            if(distance_buraco <= 1)
            {
                Destroy(gameObject);
            }
        }
      
    

    }

    private void OnTriggerEnter(Collider other)
    {
        string nome = other.gameObject.name;

        if (other.gameObject.tag == "AreaTorre")
        {
            torreAfrente = true;
        }
    }
}
