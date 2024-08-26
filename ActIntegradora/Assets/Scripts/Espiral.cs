using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espiral : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;   // Posición donde se instanciará el objeto
    public float[] hojas = new float[] {0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f}; // Ángulo en grados para la rotación


    public float timeSinceLastSpawn = 0f;
    public float timeLimit = 0.5f;



    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack(){
        Vector3 currentRotation = transform.rotation.eulerAngles;
        // Incrementar el tiempo transcurrido
        timeSinceLastSpawn += Time.deltaTime;
        
        


        // Verificar si ha pasado el intervalo de generación
        if (timeSinceLastSpawn > timeLimit)
        {
            for(int i = 0; i<8 ; i++){
                // Convertir el ángulo a un Quaternion para la rotación
                Quaternion rotation = Quaternion.Euler(0, 0, hojas[i]);
                // Instanciar el objeto con la posición y la rotación especificadas
                Instantiate(prefab, spawnPosition.position, rotation);
                hojas[i] += 10f;
                timeSinceLastSpawn = 0f;
                if(hojas[i] > 360){
                    hojas[i] = 0f;
                }
            }    
        }
    }
}
