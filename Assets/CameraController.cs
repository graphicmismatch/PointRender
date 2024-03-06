using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float Rotspeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"),0);
        this.transform.eulerAngles -= mov*Rotspeed*Time.deltaTime;
    }
}
