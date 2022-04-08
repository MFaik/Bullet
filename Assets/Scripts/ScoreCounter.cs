using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    float epoch = 0;
    bool active = true;

    static ScoreCounter Instance;

    void Awake() {
        Instance = this; 

        Score = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if(active)
            epoch += Time.deltaTime;
        Score.text = (int)epoch+"";
    }
    
    public static void StopGame() {
        Instance.active = false;
    }
}
