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
        int contAcucar;
        public Text pointstxt, lifestxt;
        public int pontos, lifes;
        bool perdeu;
        public GameObject telaGameOver;

        public static Sistema Instance;

        void Start()
        {
            Instance = this;
            pontos = 0;
            lifes = 10;
            perdeu = false;
            contAcucar = 5;
        }

        // Update is called once per frame
        void Update()
        {

            if(contAcucar == 0)
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

            pointstxt.text = "Pontos: " + pontos.ToString();
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

        public void AtualizarAcucar()
        {
            center.transform.FindChild("Açucar" + contAcucar.ToString()).gameObject.SetActive(false);
            contAcucar -= 1;
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