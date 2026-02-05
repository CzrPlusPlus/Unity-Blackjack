using UnityEngine;
using TMPro;

public class SessionTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime;
    private bool gameActive;

    void Awake()
    {
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(); 
        }  
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"Time: {minutes:0}:{seconds:00}";
    }

    public void StopTimer() { gameActive = false; }
}
