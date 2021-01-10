using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float _minSpeed;
    public float _maxSpeed = 0f;
    public ETypeShoot _type = 0f;
    float _speed = 0f;

    void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + Vector3.down * Time.deltaTime * _speed;
        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Shoot shoot = other.gameObject.GetComponent<Shoot>();
        if (shoot != null)
        {
            if (shoot.Type == _type)
            {
                Destroy(shoot.gameObject);
                Destroy(gameObject);
            }
        }

        ShipController ship = other.gameObject.GetComponent<ShipController>();
        if (ship != null)
        {
            Debug.Log("You loose");
        }
    }
}
