using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Spawn : MonoBehaviour
{
    private Transform minArea;
    private Transform maxArea;
    public GameObject ant;
    private float time;
    private float waitTime;
    private Plane a;
    public GameObject center;
    public Transform hmmm;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        waitTime = 0;
        minArea = transform.GetChild(0);
        maxArea = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        Spanw();
    }

    void Spanw()
    {
        if(center.active == true)
        {
            
            time += Time.deltaTime;
            if (time > waitTime)
            {
                            Vector3 pos = new Vector3(Random.Range(minArea.position.x, maxArea.position.x), Random.Range(minArea.position.y, maxArea.position.y), Random.Range(minArea.transform.position.z, maxArea.transform.position.z));
                //Vetor3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                //GameObject.Instantiate(ant, pos,transform.rotation);
                //GameObject.Instantiate(ant, pos, hmmm.rotation);
                GameObject.Instantiate(ant, pos, hmmm.rotation);

                waitTime = Random.Range(10.0f, 15.0f);
                time = 0;
            }
        }
    }




}
