using System.Collections;
using UnityEngine;

public class PolesSpawner : MonoBehaviour
{

    [SerializeField] private Transform poles;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float polesHeightVarience = 3f;
    [SerializeField] private float polesLifeTime = 4f;

    private void Start()
    {
        StartCoroutine(spawnPoles());
    }

    IEnumerator spawnPoles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Vector3 position = transform.position+new Vector3(0,GetRandomHeight(),0);

            Transform instanceTransform = Instantiate(poles, position,Quaternion.identity);
            Destroy(instanceTransform.gameObject, polesLifeTime);
        }
    }
    private float GetRandomHeight()
    {
        return Random.Range(-polesHeightVarience, polesHeightVarience);
    }
}
