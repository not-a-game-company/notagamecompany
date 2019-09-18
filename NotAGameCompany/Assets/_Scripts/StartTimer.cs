using TMPro;
using UnityEngine;
using  UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public static float countDownTimer = 2;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (countDownTimer <= 0) return;
        text.text = "Game Starts in: " + countDownTimer; 
        countDownTimer -= Time.deltaTime; 
    }
}
