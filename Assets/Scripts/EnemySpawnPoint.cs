using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;

    public void Spawn()
    {
        if (transform.childCount < 3)
        {
            Instantiate(enemy, transform);
        }
    }
}
