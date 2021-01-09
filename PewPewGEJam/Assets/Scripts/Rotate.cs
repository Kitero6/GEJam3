using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	[SerializeField]
	float degreesPerSecond = 0;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate( 0, 0, degreesPerSecond * Time.deltaTime );
	}
}
