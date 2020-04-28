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
                    transform.LookAt(center.transform.position);
                    movimento.x = 0;
                    movimento.y = -4 * Time.deltaTime;
                    movimento.z = vel * Time.deltaTime;
                }

                movimento = transform.TransformDirection(movimento);
                CC.Move(movimento);
            }
            else if (_return == true && pegar == true)
            {
                Sistema.Instance.AtualizarAcucarCenter();
                pegar = false;
            }
            else if (_return == true)
            {

                transform.LookAt(origem);

                movimento.x = 0;
                movimento.y = -4 * Time.deltaTime;
                movimento.z = velCarregando * Time.deltaTime;

                movimento = transform.TransformDirection(movimento);
                CC.Move(movimento);

                if (distance_buraco <= 1.5)
                {
                    Sistema.Instance.AtualizarHudAcucar();
                    Destroy(gameObject);
                    Sistema.Instance.AtualizarLifes(-1);
                }
            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
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