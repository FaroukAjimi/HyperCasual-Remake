using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
       // this.transform.position = (player.position + offset) * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * 100);
        //transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, Time.deltaTime * 100);
    }
}
