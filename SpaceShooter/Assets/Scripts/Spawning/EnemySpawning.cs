using UnityEngine;

public class EnemySpawning : PlayerProjectileSpawning
{
    public override void Spawn()
    {
        if (_allowSpawn)
        {
            _allowSpawn = false;
            Instantiate(toBeSpawned, transform.position, Quaternion.identity);
            StartCoroutine(Timer());
        }
    }
}