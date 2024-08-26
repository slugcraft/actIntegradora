using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;

    public GameObject u;
    public GameObject m;
    public GameObject a;

    private Espiral enemy1Script;
    private Flor enemy2Script;

    public Vector3 pointA;  // Punto de inicio
    public Vector3 pointB;  // Punto final

    public Vector3 pointC;  // Punto de inicio
    public Vector3 pointD;  // Punto final
    public float speed = 1.0f; // Velocidad de movimiento

    private float startTime;

    private float journeyLength1;
    private float journeyLength2;

    private bool isMoving1 = true; // Controla si el objeto debe seguir moviéndose
    private bool isMoving2 = true; // Controla si el objeto debe seguir moviéndose
    private bool flag = true;

    

    // Start is called before the first frame update
    void Start()
    {
        pointA = Boss1.transform.position;
        pointC = Boss2.transform.position;

        

        // Calcula la distancia total entre el punto A y el punto B
        journeyLength1 = Vector3.Distance(pointA, pointB);
        journeyLength2 = Vector3.Distance(pointC, pointD);


        // Obtén la referencia al script del propio GameObject
        enemy1Script = Boss1.GetComponent<Espiral>();
        enemy2Script = Boss2.GetComponent<Flor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!u && !m && !a){

        
            if (isMoving1 || isMoving2)
            {
                if (flag){
                    // Almacena el tiempo de inicio del movimiento
                    startTime = Time.time;
                    flag = false;
                }
                // Calcula cuánto tiempo ha pasado desde el inicio
                float distCovered = (Time.time - startTime) * speed;
                
                // Calcula la fracción del viaje completada
                float fractionOfJourney1 = distCovered / journeyLength1;
                // Interpola la posición del objeto entre el punto A y el punto B
                Boss1.transform.position = Vector3.Lerp(pointA, pointB, fractionOfJourney1);


                // Calcula la fracción del viaje completada
                float fractionOfJourney2 = distCovered / journeyLength2;
                // Interpola la posición del objeto entre el punto A y el punto B
                Boss2.transform.position = Vector3.Lerp(pointC, pointD, fractionOfJourney2);

                // Si ha alcanzado el punto B, detiene el movimiento
                if (fractionOfJourney1 >= 1.0f)
                {
                    isMoving1 = false; // Detener el movimiento
                }
                if (fractionOfJourney2 >= 1.0f){
                    isMoving2 = false;
                }
            }else{
                if(Boss1 != null){
                    enemy1Script.attack();
                }
                if(Boss2 != null){
                    enemy2Script.attack();
                }
            }
        }
    }
}
