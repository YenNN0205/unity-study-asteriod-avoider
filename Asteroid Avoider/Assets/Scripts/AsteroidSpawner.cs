using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{  
    [SerializeField] GameObject[] aseroidPrefabs;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] Vector2 aseroidForce;
    private float timer;
    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        Debug.Log(timer);
        if(timer <=0)
        {
            AseroidSpawn();
            timer = timer + timeBetweenSpawn;
        }
    }
    private void AseroidSpawn()
    {
        int side = Random.Range(0,4);
        Vector2 spawnPos = Vector2.zero;
        Vector2 direction = Vector2.zero;
        switch(side)
        {   
            //right
            case 0:
                spawnPos.x = 1;
                spawnPos.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f,1f));
                break;
            //left
            case 1:
                spawnPos.x = 0;
                spawnPos.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            //up
            case 2:
                spawnPos.x = Random.value;
                spawnPos.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
            //down
            case 3:
                spawnPos.x = Random.value;
                spawnPos.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
        }
        Vector3 worldSpawnPos = camera.ViewportToWorldPoint(spawnPos);
        worldSpawnPos.z =0f;
        GameObject selectedAsteroid = aseroidPrefabs[Random.Range(0, aseroidPrefabs.Length)];
        GameObject currentSpawnAsteroid = Instantiate(selectedAsteroid, worldSpawnPos, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        Rigidbody rb = currentSpawnAsteroid.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized*Random.Range(aseroidForce.x, aseroidForce.y);
    }

}
