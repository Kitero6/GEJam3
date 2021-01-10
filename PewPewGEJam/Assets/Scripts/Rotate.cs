using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField]
	float _degreesPerSecond = 0;

	[SerializeField]
	float _randomSpeedValue = 0f;

	float _speed = 0f;
	int _dir = 0;
	
	void Start()
	{
		_dir = Random.Range(0, 1) == 0 ? -1 : 1; 
		_speed = _degreesPerSecond + Random.Range(-_randomSpeedValue, _randomSpeedValue); 
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate( 0, 0, _dir * _speed * Time.deltaTime );
	}
}
