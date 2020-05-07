using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjAR
{
    public class Spray : MonoBehaviour
    {

        private Transform target;
        public float range;
        private Transform partToRotate;
        public float turnSpeed;

        private float fireCountdown = 0f;
        public float fireRate = 1f;
        public float porrada = 100;

        private BoxCollider colisor;


        public GameObject particulas;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
            partToRotate = transform;

            colisor = GetComponent<BoxCollider>();

            colisor.enabled = false;

            particulas.GetComponent<ParticleSystem>().enableEmission = false;

        }

        // Update is called once per frame
        void Update()
        {

            if (target == null)
            {
                particulas.GetComponent<ParticleSystem>().enableEmission = false;
                return;
            }


            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);

            if (fireCountdown <= 0)
            {
                Shot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }

        private void Shot()
        {
            Sistema.Instance.PlaySFX(Sistema.Instance.spray, 0.6f);
            colisor.enabled = true;
            particulas.GetComponent<ParticleSystem>().enableEmission = true;
            Debug.Log("bah");
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ant");
            float shortestDistance = Mathf.Infinity;
            GameObject nearstEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearstEnemy = enemy;
                }
            }

            if (nearstEnemy != null && shortestDistance <= range)
            {
                target = nearstEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, range);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Ant")
            {
                Debug.Log("ué");
                other.gameObject.GetComponent<ProjAR.FumigaTeste>().TomandoPorrada(porrada);
            }

            colisor.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ant")
            {
                Debug.Log("ué 2");
                other.gameObject.GetComponent<ProjAR.FumigaTeste>().TomandoPorrada(porrada);
            }

            colisor.enabled = false;
        }


    }
}