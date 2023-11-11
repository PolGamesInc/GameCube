using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 20;
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private GameObject[] Obstacle;

    private void Start()
    {
        SpawnObstacle();
        Obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    private void Update()
    {
        Move();
    }

    private void SpawnObstacle()
    {
        for (int i = 0; i < 15; i++)
        {
            Instantiate(ObstaclePrefab, new Vector3(Random.Range(-45, 45), 1.5f, Random.Range(-45, 45)), Quaternion.Euler(0, 0, 0));
        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * h);

        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * v);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obstacle = other.gameObject;

        if (other.tag == "Obstacle")
        {
            for (int i = 0; i < Obstacle.Length; i++)
            {
                if(obstacle == Obstacle[i])
                {
                    Destroy(obstacle);
                    break;
                }
            }
        }
    }

}