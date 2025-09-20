using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public Timer tiempoEscena;


    public GameObject apple;
    public GameObject Banana;

    public int maxManzanas = 5;
    public int maxBananas = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        public List<GameObject> puntosDisponibles = new List<GameObject>();

    void Start()
    {

        // Generar manzanas
        int cantidadManzanas = Random.Range(1, maxManzanas + 1);
        for (int i = 0; i < cantidadManzanas; i++)
        {
            GenerarFruta(apple);
        }

        // Generar bananas
        int cantidadBananas = Random.Range(1, maxBananas + 1);
        for (int i = 0; i < cantidadBananas; i++)
        {
            GenerarFruta(Banana);
        }
    }

    void GenerarFruta(GameObject frutaPrefab)
    {
        if (puntosDisponibles.Count == 0) return;

        int index = Random.Range(0, puntosDisponibles.Count);
        GameObject punto = puntosDisponibles[index];

        Instantiate(frutaPrefab, punto.transform.position, Quaternion.identity);

        puntosDisponibles.RemoveAt(index);
    }
}

    // Update is called once per frame
    void Update()
    {

    }

    public void addTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 1 " + GameManager.Instance.GlobalTime);
    }
}
