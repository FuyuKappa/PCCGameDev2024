using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform HPVal;
    [SerializeField]
    private TMP_Text HPText;

    private const float HPBarMaxWidth = 490f;

    void Update(){
        int maxHP = PlayerStats.GetMaxHP();
        int currHP = PlayerStats.GetHP();
        
        float HPPercent = (float)currHP / (float)maxHP;
        HPVal.sizeDelta = new Vector2(HPBarMaxWidth * HPPercent, 30);

        HPText.text = currHP + "/" + maxHP;
    }
}
