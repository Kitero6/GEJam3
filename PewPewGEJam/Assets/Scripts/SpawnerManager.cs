using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] _meteorAPrefabs = null;
    public GameObject[] _meteorBPrefabs = null;
    
    public Transform _topLeftPosOfPlayerZone = null;
    public Transform _topLeftPosOfCloneZone = null;

    public float _widthPlayZone = 0f;
    public float _distanceFromTopToSpawn = 0f;
    public float _distanceFromEdges = 0f;

    public float _spawnIntensity = 10f;
    float _spawnTimer = 0f;
    float _elapsedTime = 0f;

    void Start()
    {
        _elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        _spawnTimer -= Time.deltaTime;

        while (_spawnTimer <= 0f)
        {
            // Choose the player to spawn 0=player 1=clone
            int player = Random.Range(0, 2);
            Transform transformPlayZone;
            if (player == 0)
                transformPlayZone = _topLeftPosOfPlayerZone; 
            else
                transformPlayZone = _topLeftPosOfCloneZone; 

            // Get the spawn position
            float xToSpawn = Random.Range(0f, _widthPlayZone - _distanceFromEdges) + _distanceFromEdges / 2f;
            Vector3 spawnPos = new Vector3(xToSpawn + transformPlayZone.position.x, _distanceFromTopToSpawn + transformPlayZone.position.y, 0f);

            // Get a random rotation
            Quaternion spawnRot = Quaternion.AngleAxis(Random.Range(-Mathf.PI, Mathf.PI), Vector3.forward);

            // Get the right type to spawn
            GameObject meteor = null;
            ETypeShoot type = (ETypeShoot)Random.Range(0, 2);
            switch (type)
            {
                case ETypeShoot.A: meteor = _meteorAPrefabs[Random.Range(0, _meteorAPrefabs.Length)]; break;
                case ETypeShoot.B: meteor = _meteorBPrefabs[Random.Range(0, _meteorAPrefabs.Length)]; break;
            }

            // Spawn
            Instantiate(meteor, spawnPos, spawnRot);

            _spawnTimer += ComputeTimer(_elapsedTime);
        }
    }

    float ComputeTimer(float x)
    {
        return 1f / Mathf.Log(x + 3f, _spawnIntensity);
    }
}
