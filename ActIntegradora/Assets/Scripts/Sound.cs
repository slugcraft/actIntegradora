using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;       // Referencia al componente AudioSource
    public AudioClip firstClip;           // Primera pista musical
    public AudioClip secondClip; 
    private bool hasSwitched = false; 
    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    // Start is called before the first frame update
    void Start()
    {
        // Asignar la primera pista y reproducirla
        audioSource.clip = firstClip;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si han pasado los 10 segundos y si aún no se ha cambiado la pista
        if (!enemy1 && !enemy2 && !enemy3 && !hasSwitched)
        {
            // Cambiar a la segunda pista
            audioSource.clip = secondClip;
            audioSource.Play();

            // Marcar que ya se hizo el cambio
            hasSwitched = true;
        }
    }
}
