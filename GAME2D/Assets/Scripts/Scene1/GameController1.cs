    using UnityEngine;
using TMPro;

    public class GameController1 : MonoBehaviour
{
    public Timer tiempoEscena;
    public TextMeshProUGUI TextApple;
    public TextMeshProUGUI TextBanana;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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

        Debug.Log("Tiempo Escena 1 " + GameManager.Instance.GlobalTime);
    }
}

    
