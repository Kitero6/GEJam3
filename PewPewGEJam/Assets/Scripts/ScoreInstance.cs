using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInstance : MonoBehaviour
{
    public static ScoreInstance instance = null;

    public float timeElapsed = 0f;
    public int score = 0;

    void Start()
    {
        if (instance == null)    
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timeElapsed = 0f;
        score = 0;
    }
}
