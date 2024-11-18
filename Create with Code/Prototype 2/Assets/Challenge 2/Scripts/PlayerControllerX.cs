using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float spawnCooldown = 2f;
    private bool canSpawn = true;

    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space)&& canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            StartCoroutine(SpawnCooldownCoroutine());
        }
    }

    IEnumerator SpawnCooldownCoroutine()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }
}
