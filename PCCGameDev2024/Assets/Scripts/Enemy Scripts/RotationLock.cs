using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0f, -transform.parent.rotation.y, 0f);
    }
}
