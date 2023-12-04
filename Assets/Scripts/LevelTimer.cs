using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private float MaxDuration = 0.0f;
    private float CurrentDuration = 0.0f;
    [SerializeField] private TextMeshProUGUI TimerText;
    bool IsStartTimer = false;
    private string Explanation = "";
    public delegate void CallbackDelegate();
    private CallbackDelegate TimerEndCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStartTimer)
        {
            if (CurrentDuration > 0)
            {
                CurrentDuration -= Time.deltaTime;
                ShowTimerUI(CurrentDuration);
            }
            else
            {
                TimerEndCallback();
                IsStartTimer = false;
            }
        }
    }

    public void SetCallback(CallbackDelegate i_NewCallback)
    {
        TimerEndCallback = i_NewCallback;
    }

    public void StartTimer()
    {
        CurrentDuration = MaxDuration;
        ContinueTimer();
    }

    public void ContinueTimer()
    {
        IsStartTimer = true;
    }

    public void SetMaxDuration(float i_MaxDuration)
    {
        MaxDuration = i_MaxDuration;
    }

    public void UpdateExplanation(string i_Exp)
    {
        Explanation = i_Exp;
    }

    void ShowTimerUI(float i_Time)
    {
        int Timer = (int)i_Time;
        TimerText.text = Explanation + Timer;
    }
}
