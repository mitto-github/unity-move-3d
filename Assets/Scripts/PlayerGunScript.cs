using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Camera PlayerCamera;
    // private float _power = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject bulletObject = Instantiate (BulletPrefab);
            bulletObject.transform.position = PlayerCamera.transform.position + PlayerCamera.transform.forward;
            bulletObject.transform.forward = PlayerCamera.transform.forward;
        }
    }
}
