using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject enemy1;
    private Circulos enemy1Script;

    public GameObject enemy2;
    private Circulos enemy2Script;

    public GameObject enemy3;
    private Circulos enemy3Script;


    public Vector3 pointA;  // Punto de inicio
    public Vector3 pointB;  // Punto final

    public Vector3 pointC;  // Punto de inicio
    public Vector3 pointD;  // Punto final

    public Vector3 pointE;  // Punto de inicio
    public Vector3 pointF;  // Punto final

    public float speed = 1.0f; // Velocidad de movimiento

    private float startTime;
    private float journeyLength1;
    private float journeyLength2;
    private float journeyLength3;
    private bool isMoving1 = true; // Controla si el objeto debe seguir moviéndose
    private bool isMoving2 = true; // Controla si el objeto debe seguir moviéndose
    private bool isMoving3 = true; // Controla si el objeto debe seguir moviéndose
    // Start is called before the first frame update
    void Start()
    {
        // Almacena el tiempo de inicio del movimiento
        startTime = Time.time;

        // Calcula la distancia total entre el punto A y el punto B
        journeyLength1 = Vector3.Distance(pointA, pointB);
        journeyLength2 = Vector3.Distance(pointC, pointD);
        journeyLength3 = Vector3.Distance(pointE, pointF);


        // Obtén la referencia al script del propio GameObject
        enemy1Script = enemy1.GetComponent<Circulos>();
        enemy2Script = enemy2.GetComponent<Circulos>();
        enemy3Script = enemy3.GetComponent<Circulos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving1 || isMoving2 || isMoving3)
        {
            // Calcula cuánto tiempo ha pasado desde el inicio
            float distCovered = (Time.time - startTime) * speed;
            
            // Calcula la fracción del viaje completada
            float fractionOfJourney1 = distCovered / journeyLength1;
            // Interpola la posición del objeto entre el punto A y el punto B
            enemy1.transform.position = Vector3.Lerp(pointA, pointB, fractionOfJourney1);


            // Calcula la fracción del viaje completada
            float fractionOfJourney2 = distCovered / journeyLength2;
            // Interpola la posición del objeto entre el punto A y el punto B
            enemy2.transform.position = Vector3.Lerp(pointC, pointD, fractionOfJourney2);


            // Calcula la fracción del viaje completada
            float fractionOfJourney3 = distCovered / journeyLength3;
            // Interpola la posición del objeto entre el punto A y el punto B
            enemy3.transform.position = Vector3.Lerp(pointE, pointF, fractionOfJourney3);
    
            // Si ha alcanzado el punto B, detiene el movimiento
            if (fractionOfJourney1 >= 1.0f)
            {
                isMoving1 = false; // Detener el movimiento
            }
            if (fractionOfJourney2 >= 1.0f){
                isMoving2 = false;
            }
            if (fractionOfJourney3 >= 1.0f){
                isMoving3 = false;
            }

        }else{
            if(enemy1 != null){
                enemy1Script.attack();
            }
            if(enemy2 != null){
                enemy2Script.attack();
            }
            if(enemy3 != null){
                enemy3Script.attack();
            }
        }


    }
}
