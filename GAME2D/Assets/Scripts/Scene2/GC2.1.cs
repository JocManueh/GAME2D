using TMPro;
using UnityEngine;
using System.IO;
using System;


public class GameController2 : MonoBehaviour
{
    [Header("Timer")]
    public Timer tiempoEscena2;

    [Header("Contadores en tiempo real")]
    public TextMeshProUGUI TextApple;
    public TextMeshProUGUI TextBanana;

    [Header("Panel de Resultados")]
    public GameObject panelResultados;
    public TextMeshProUGUI tiempoTotalText;
    public TextMeshProUGUI puntosAppleText;
    public TextMeshProUGUI puntosBananaText;
    public TextMeshProUGUI puntajeTotalText;

    [Header("Botones")]
    public UnityEngine.UI.Button botonGuardar;

    private void Start()
    {
        // Asegurar que el panel esté oculto al inicio
        if (panelResultados != null)
            panelResultados.SetActive(false);

        // Configurar el botón de guardar
        if (botonGuardar != null)
            botonGuardar.onClick.AddListener(GuardarDatos);
    }

    void Update()
    {
        // Actualizar contadores en tiempo real durante el juego
        if (GameManager.Instance != null && TextApple != null && TextBanana != null)
        {
            int apples = GameManager.Instance.ScoreApple;
            int bananas = GameManager.Instance.ScoreBanana;
            TextApple.text = apples.ToString();
            TextBanana.text = bananas.ToString();
        }
    }

    public void EndScene2()
    {
        // 1. Detener el timer de la escena 2
        tiempoEscena2.TimerStop();
        float getTimeScene2 = tiempoEscena2.StopTime;

        // 2. Acumular en el GameManager
        GameManager.Instance.TotalTime(getTimeScene2);

        // 3. Mostrar resultados en el panel
        MostrarResultados();

        // 4. Activar el panel de resultados
        if (panelResultados != null)
            panelResultados.SetActive(true);
    }

    private void MostrarResultados()
    {
        if (GameManager.Instance != null)
        {
            float tiempoTotal = GameManager.Instance.GlobalTime;
            int manzanas = GameManager.Instance.ScoreApple;
            int bananas = GameManager.Instance.ScoreBanana;
            int puntajeTotal = manzanas + bananas;

            // Actualizar textos del panel
            if (tiempoTotalText != null)
                tiempoTotalText.text = "Tiempo Total: " + tiempoTotal.ToString("F2") + " s";

            if (puntosAppleText != null)
                puntosAppleText.text = "Manzanas: " + manzanas;

            if (puntosBananaText != null)
                puntosBananaText.text = "Bananas: " + bananas;

            if (puntajeTotalText != null)
                puntajeTotalText.text = "Puntaje Total: " + puntajeTotal;
        }
    }

    public void GuardarDatos()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager no encontrado");
            return;
        }

        // Crear objeto con los datos del juego
        GameData datosJuego = new GameData
        {
            tiempoTotal = GameManager.Instance.GlobalTime,
            puntajeManzanas = GameManager.Instance.ScoreApple,
            puntajeBananas = GameManager.Instance.ScoreBanana,
            puntajeTotal = GameManager.Instance.ScoreApple + GameManager.Instance.ScoreBanana,
            fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        // Convertir a JSON
        string jsonString = JsonUtility.ToJson(datosJuego, true);

        // Crear nombre de archivo único
        string fileName = "GameData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            // Guardar archivo
            File.WriteAllText(filePath, jsonString);
            Debug.Log("Datos guardados exitosamente en: " + filePath);
            Debug.Log("Contenido JSON: " + jsonString);
        }
        catch (Exception e)
        {
            Debug.LogError("Error al guardar los datos: " + e.Message);
        }
    }

    // Método opcional para cargar datos (si lo necesitas después)
    public GameData CargarDatos(string nombreArchivo)
    {
        string filePath = Path.Combine(Application.persistentDataPath, nombreArchivo);

        if (File.Exists(filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                GameData datosJuego = JsonUtility.FromJson<GameData>(jsonString);
                Debug.Log("Datos cargados exitosamente desde: " + filePath);
                return datosJuego;
            }
            catch (Exception e)
            {
                Debug.LogError("Error al cargar los datos: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Archivo no encontrado: " + filePath);
            return null;
        }
    }
}
