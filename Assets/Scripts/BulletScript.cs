using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float _speed = 80f;
    private float _lifeDuration = 2f;
    private float _lifeTimer;
    
    // Use this for initialization
    void Start () {
        _lifeTimer = _lifeDuration;
    }
    
    // Update is called once per frame
    void Update () {
        // Make the bullet move.
        transform.position += transform.forward * _speed * Time.deltaTime;

        // Check if the bullet should be destroyed.
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0f) {
            Destroy(gameObject);
        }
    }
}
