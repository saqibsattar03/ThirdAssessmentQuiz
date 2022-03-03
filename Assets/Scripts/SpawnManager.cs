using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject animalPrefab;
    public GameObject player;
    public GameObject instantiatedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnimal());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(instantiatedPrefab);
    }

    IEnumerator SpawnAnimal() 
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        instantiatedPrefab = Instantiate(animalPrefab,spawnPos,playerRotation) as GameObject;

        yield return new WaitForSeconds(5.0f);
        StartCoroutine(SpawnAnimal());

    }
}
