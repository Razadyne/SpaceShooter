using System.Collections;
using UnityEngine;

public class PlayerProjectileSpawning : MonoBehaviour
{
    [Range(1f, 0f)][SerializeField] public float _spawnRate;
    
    [HideInInspector] public bool _allowSpawn = true;
    
    [Header("Spawned Game Object")]
    public GameObject toBeSpawned;

    public void Update()
    {
        Spawn();
    }

    public virtual void Spawn()
    {
        if (Input.GetMouseButton(0) && _allowSpawn)
        {
            _allowSpawn = false;
            Instantiate(toBeSpawned, transform.position, Quaternion.identity);
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(_spawnRate);
        _allowSpawn = true;
    }
}
