using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBlockScript : MonoBehaviour
{
    public void Picked(){
        StartGameController.startingBlock = this.GetComponent<Block>();
    }
}
