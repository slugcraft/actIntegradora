using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circulos : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;   // Posición donde se instanciará el objeto

    public float timeSinceLastSpawn = 0f;
    public float timeLimit = 1f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attack(){
        // Incrementar el tiempo transcurrido
        timeSinceLastSpawn += Time.deltaTime;
        float angulo = 0f;
        


        // Verificar si ha pasado el intervalo de generación
        if (timeSinceLastSpawn > timeLimit)
        {
            for(int i = 0; i<18 ; i++){
                // Convertir el ángulo a un Quaternion para la rotación
                Quaternion rotation = Quaternion.Euler(0, 0, angulo);
                // Instanciar el objeto con la posición y la rotación especificadas
                Instantiate(prefab, spawnPosition.position, rotation);
                
                angulo += 20f;
            }    
            timeSinceLastSpawn = 0f;
            angulo+=0f;
        }
    }
    
}
