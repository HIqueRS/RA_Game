using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
//using System.IO;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

namespace ProjAR
{
    public class Sistema : MonoBehaviour
    {
        [Header("Audio")]
        public AudioSource sfxSource;
        public AudioSource musicSource;

        [Header("Effects")]
        //aqui é pra ir os efeitos sonoros

        public GameObject center;
        int contAcucarCenter, contAcucarPerdidos;
        public Text pointstxt, lifestxt;
        public int pontos, lifes;
        bool perdeu;
        public GameObject telaGameOver, gerHudAcucar;

        public static Sistema Instance;

        void Start()
        {
            Instance = this;
            pontos = 0;
            lifes = 10;
            perdeu = false;
            contAcucarCenter = contAcucarPerdidos = 5;
        }

        // Update is called once per frame
        void Update()
        {

            if(contAcucarPerdidos == 0)
            {
                telaGameOver.SetActive(true);
            }
            //if (perdeu == true)
            //{
            //    print("PERDEDOR");
            //}
        }

        public void AtualizarPoints(int p)
        {
            pontos += p;

            pointstxt.text = "Fumigas Mortas: " + pontos.ToString();
        }

        public void AtualizarLifes(int l)
        {
            lifes += l;

            lifestxt.text = "Lifes: " + lifes.ToString();

            if (lifes == 0)
            {
                perdeu = true;
            }
        }

        public void AtualizarAcucarCenter()
        {
<<<<<<< HEAD
            center.transform.Find("Açucar" + contAcucar.ToString()).gameObject.SetActive(false);
            contAcucar -= 1;
=======
            center.transform.FindChild("Açucar" + contAcucarCenter.ToString()).gameObject.SetActive(false);
            contAcucarCenter -= 1;
>>>>>>> ada140a841edab60023d1f42b7ae4d1490da7989
        }

        public void AtualizarHudAcucar()
        {
            gerHudAcucar.transform.FindChild("Acucar" + contAcucarPerdidos.ToString()).gameObject.SetActive(false);
            contAcucarPerdidos -= 1;
        }

        public void Reiniciar()
        {
            SceneManager.LoadScene("Raulo");
        }


        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void PlaySFX(AudioClip sfxClip, float volume) // volume de 0.0 a 1 ( se n me engano )
        {
            sfxSource.PlayOneShot(sfxClip, volume);
        }
    }
}