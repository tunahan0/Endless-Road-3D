using System.Collections;
using UnityEngine;

public class AICarSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] carAIPrefabs;

    GameObject[] carAIPool = new GameObject[20];

    Transform playerCarTransform;

    float timeLastCarSpawned = 0;
    WaitForSeconds wait = new WaitForSeconds(0.5f);

    [SerializeField]
    LayerMask otherCarsLayerMask;

    Collider[] overlappedCheckCollider = new Collider[1];

    void Start()
    {
        playerCarTransform = GameObject.FindGameObjectWithTag("Player").transform;

        int prefabIndex = 0;

        for (int i = 0; i < carAIPool.Length; i++) 
        {
            carAIPool[i] = Instantiate(carAIPrefabs[prefabIndex]);
            carAIPool[i].SetActive(true);

            prefabIndex++;

            if(prefabIndex > carAIPrefabs.Length - 1)
                prefabIndex = 0;
        }

        StartCoroutine(UpdateLessOftenCO());
    }


    IEnumerator UpdateLessOftenCO()
    {
        while (true)
        {
            CleanUpCarsBeyondView();
            SpawnNewCars();
            yield return wait;
        }
    }

    void SpawnNewCars()
    {
        if (Time.time - timeLastCarSpawned < 2)
            return;

        GameObject carToSpawn = null;

        foreach (GameObject aicar in carAIPool)
        {
            if(aicar.activeInHierarchy)
                continue;

            carToSpawn = aicar;
            break;
        }

        if(carToSpawn == null)
            return;

        Vector3 spawnPosition = new Vector3(0,0, playerCarTransform.transform.position.z + 200);

        if (Physics.OverlapBoxNonAlloc(spawnPosition, Vector3.one * 2, overlappedCheckCollider, Quaternion.identity, otherCarsLayerMask) > 1)
            return;
        
        carToSpawn.transform.position = spawnPosition;
        carToSpawn.SetActive(true); 

        timeLastCarSpawned = Time.time;
    }

    void CleanUpCarsBeyondView()
    {
        foreach (GameObject aicar in carAIPool)
        {
            if(!aicar.activeInHierarchy) 
                continue;

            if(aicar.transform.position.z - playerCarTransform.position.z > 250)
                aicar.SetActive(false);

            if (aicar.transform.position.z - playerCarTransform.position.z < -50) 
                aicar.SetActive(false);

        }
    }
}
