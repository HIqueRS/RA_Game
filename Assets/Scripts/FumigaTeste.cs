using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace ProjAR
{
    public class FumigaTeste : MonoBehaviour
    {
        public GameObject center, buraco;
        Vector3 origem;

       // public Transform hmmmm;

        #region variaveis
        public float vel = 2;
        float velCarregando;
        public bool _return;
        public Vector3 movimento;
        public float distance_center, distance_buraco;
        public bool torreAfrente;
        float HpTotal;
        public float HpAtual;
        public bool pegar;
        #endregion

        CharacterController CC;
        public GameObject HMMMM;

        // Start is called before the first frame update
        void Start()
        {
            velCarregando = 1;
            _return = false;
            CC = GetComponent<CharacterController>();
            torreAfrente = false;
            HpAtual = HpTotal = 100f;
            origem = gameObject.transform.position;
            pegar = true;

            center = GameObject.FindGameObjectWithTag("Center");

            HMMMM = GameObject.FindGameObjectWithTag("HMM");
        }

        // Update is called once per frame
        void Update()
        {
            Viva();
            distance_center = Vector3.Distance(transform.position, center.transform.position);
            distance_buraco = Vector3.Distance(transform.position, origem);

            if (distance_center <= 1)
            {
                _return = true;
                gameObject.transform.Find("açucar").gameObject.SetActive(true);
            }
            if (_return == false)
            {
                if (torreAfrente == true)
                {
                    movimento.z = 0;
                    movimento.x = vel * Time.deltaTime;
                    torreAfrente = false;
                }
                else
                {
                   
                    //Vector3 dir = center.transform.position - transform.position;
                    //Quaternion lookRotation = Quaternion.LookRotation(dir);
                    //Vector3 rotation = lookRotation.eulerAngles;
                    //transform.localRotation = Quaternion.LookRotation(dir);
                }
                transform.LookAt(center.transform.position);
              

                 CC.Move(transform.forward * Time.deltaTime);


            }
            else if (_return == true && pegar == true)
            {
                Sistema.Instance.AtualizarAcucarCenter();
                pegar = false;
            }
            else if (_return == true)
            {

                 transform.LookAt(origem);

                //Vector3 dir = origem - transform.position;
                //Quaternion lookRotation = Quaternion.LookRotation(dir);
                //Vector3 rotation = lookRotation.eulerAngles;
                //transform.localRotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);


                //movimento = transform.TransformDirection(movimento);
                CC.Move(transform.forward * Time.deltaTime);

                if (distance_buraco <= 1.5)
                {
                    Sistema.Instance.AtualizarHudAcucar();
                    Destroy(gameObject);
                    Sistema.Instance.AtualizarLifes(-1);
                }

               
            }
            //transform.eulerAngles = new Vector3(HMMMM.transform.eulerAngles.x, HMMMM.transform.eulerAngles.y, HMMMM.transform.eulerAngles.z);
           
        }

        private void OnTriggerEnter(Collider other)
        {
            string nome = other.gameObject.name;

            if (other.gameObject.tag == "AreaTorre")
            {
                torreAfrente = true;
            }
        }

        public void TomandoPorrada(float dps)
        {
            HpAtual -= dps;
        }

        private void Viva()
        {
            if (HpAtual <= 0)
            {
                Sistema.Instance.AtualizarPoints(1);
                Destroy(gameObject);
                print("Destruido porq MORREO");
            }
        }
    }
}