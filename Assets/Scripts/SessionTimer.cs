using UnityEngine;
using TMPro;

public class SessionTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"Time: {minutes:0}:{seconds:00}";
    }
}
