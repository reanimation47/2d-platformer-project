using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessModeController : MonoBehaviour
{
    public TextMeshProUGUI Score;
    float time_passed = 0;
    GameObject Player;
    private int current_score;

    private void Start()
    {
        Player = ICommon.GetPlayerObject();
    }

    private void Update()
    {
        if (!Player) { return; }
        time_passed += Time.deltaTime;
        int seconds = (int)(time_passed % 60);
        Score.text = "" + seconds;
        current_score = seconds;
    }

    public int GetCurrentScore()
    {
        return current_score;
    }

    public void ToggleEndlessView(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
