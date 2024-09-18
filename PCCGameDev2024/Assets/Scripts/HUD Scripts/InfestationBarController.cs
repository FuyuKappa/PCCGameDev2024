using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfestationBarController : MonoBehaviour
{
    [SerializeField]
    private LevelController lc;
    [SerializeField]
    private TMP_Text WaveText;

    private const float barMaxWidth = 485f;

    void Update()
    {
        float WavePercent = ((float)lc.GetEnemyCount() - (float)lc.GetEnemiesKilled()) / (float)lc.GetEnemyCount();
        WavePercent = Mathf.Round(WavePercent * 10.0f) * 0.1f;
        WaveText.text = WavePercent * 100 + "%";
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(barMaxWidth * WavePercent, 30);
    }
}