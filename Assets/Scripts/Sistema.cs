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
        public AudioClip[] fumigasMorrendo;
        public AudioClip spray;
        public AudioClip button;

        [Header("Outros bgl")]
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

            center.transform.Find("Açucar" + contAcucarCenter.ToString()).gameObject.SetActive(false);
            contAcucarCenter -= 1;

        }

        public void AtualizarHudAcucar()
        {
            gerHudAcucar.transform.Find("Acucar" + contAcucarPerdidos.ToString()).gameObject.SetActive(false);
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

        public void PlaySFXPqOBotaoNaoAceitaDoisParametros()
        {
            PlaySFX(button, 1.0f);
        }
    }
}