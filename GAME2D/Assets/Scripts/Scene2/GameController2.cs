using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public Timer tiempoEscena;
    public TextMeshProUGUI TextApple;
    public TextMeshProUGUI TextBanana;

    public GameObject apple;
    public GameObject Banana;

    public int maxManzanas = 5;
    public int maxBananas = 7;

    [Header("Puntos de aparición")]
    public Transform[] spawnPoints;

    [Header("UI Panel Final")]
    public GameObject endPanel;
    public TMP_Text tiempoTotalText;
    public TMP_Text puntosManzanaText;
    public TMP_Text puntosBananaText;
    public Button guardarJsonButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
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
    void Update()
    {
        if (GameManager.Instance != null)
        {
            int apples = GameManager.Instance.ScoreApple;
            int bananas = GameManager.Instance.ScoreBanana;

            TextApple.text = apples.ToString();
            TextBanana.text = bananas.ToString();
        }

    }
    public void addTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 2" + GameManager.Instance.GlobalTime);
    }
    public void EndGame()
    {
        float tiempoTotal = Time.time - tiempoInicio;

        endPanel.SetActive(true);

        tiempoTotalText.text = $"Tiempo total: {tiempoTotal:F2} s";
        puntosManzanaText.text = $"Puntos Manzana: {puntosManzana}";
        puntosBananaText.text = $"Puntos Banana: {puntosBanana}";

        Time.timeScale = 0f; // pausa el juego
    }



}
