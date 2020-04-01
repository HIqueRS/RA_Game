using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private Transform minArea;
    private Transform maxArea;
    public GameObject ant;
    private float time;
    private float waitTime;

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
        time += Time.deltaTime;
        if (time > waitTime)
        {

            Vector3 pos = new Vector3(Random.Range(minArea.position.x, maxArea.position.x), 0, Random.Range(minArea.transform.position.z, maxArea.transform.position.z));

            GameObject.Instantiate(ant, pos, Quaternion.identity);

            waitTime = Random.Range(10.0f, 15.0f);
            time = 0;
        }
    }

}
