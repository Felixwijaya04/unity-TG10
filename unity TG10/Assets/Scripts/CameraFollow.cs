using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Followspeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float varoffsetY = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + varoffsetY, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, Followspeed*Time.deltaTime);
    }
}
