using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool spawnAble = true;
    [SerializeField] Transform enemie;
    
    [SerializeField] Transform targetPosition;
    private Vector3 currentPosition;
    private Quaternion rotation;

    private void Start()
    {

        rotation = targetPosition.rotation;
    }
    private IEnumerator coolDownSpawn()
    {
        print("spawning paused");
        yield return new WaitForSeconds(5f);
        print("Is spawnable again");
        spawnAble = true;
    }

    private void Update()
    {
        currentPosition = new Vector3(targetPosition.position.x, targetPosition.position.y, targetPosition.position.z);
        if (spawnAble)
        {
            print("Attempting spawn");
            int decree = Random.Range(0, 2);
            if (decree == 1)
            {
                print("Spawning");
                int enemies = Random.Range(1, 3);
                SpawnEnemy(enemies);
                spawnAble = false;
                StartCoroutine(coolDownSpawn());
            }
        }
    }

    private void SpawnEnemy(int enemies)
    {
        int[] positions = new int[enemies];
       if(enemies > 1)
        {
            int position1 = Random.Range(1, 3);
            int position2 = Random.Range(1, 3);
            positions[0] = position1;
            positions[1] = position2;
            
            for(int i = 0; i < positions.Length; i++)
            {
                if(positions[i] == 1)
                {
                    Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
                    Transform unit = Instantiate(enemie,intPosition,rotation);
                }
                else if (positions[i] == 2)
                {
                    Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, 3);
                    Transform unit = Instantiate(enemie, intPosition, rotation);
                }
                else if (positions[i] == 3)
                {
                    Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, -3);
                    Transform unit = Instantiate(enemie, intPosition, rotation);
                }
            }
            



        }
        else
        {
            int position1 = Random.Range(1, 3);
            if (position1 == 1)
            {
                Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);
                Transform unit = Instantiate(enemie, intPosition, rotation);
            }
            else if (position1 == 2)
            {
                Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 3);
                Transform unit = Instantiate(enemie, intPosition, rotation);
            }
            else if (position1 == 3)
            {
                Vector3 intPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - 3);
                Transform unit = Instantiate(enemie, intPosition, rotation);
            }
        }
        
    }
}
