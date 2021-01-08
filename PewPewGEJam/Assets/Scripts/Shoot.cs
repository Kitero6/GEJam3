using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float _speed = 0f;
    public ETypeShoot _type = ETypeShoot.A;

    public ETypeShoot Type { get { return _type; } }

    void Update()
    {
        Vector3 newPos = transform.position + Vector3.up * Time.deltaTime * _speed;
        transform.position = newPos;
    }
}
