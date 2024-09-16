using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyStats stats;

    [SerializeField]
    private Transform  hpScale;

    private readonly float hpBarScale = 2.74f;

    public void HandleHit(float damage){
        float HPafterHit = stats.GetHP() - damage;
        print(HPafterHit);
        if(HPafterHit <= 0) { 
            Destroy(this.gameObject); 
        }
        else{
            stats.SetHP(HPafterHit);

            float newHPBarScale = hpBarScale * (HPafterHit / stats.GetMaxHP());

            hpScale.localScale = new Vector3(newHPBarScale, hpScale.localScale.y, hpScale.localScale.z);
        }
    }
}
