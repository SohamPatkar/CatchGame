using System.Collections;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _candies;
    private float _randomTime = 2f;
    private int randomCandy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCandy();
        StartCoroutine(Time());
    }
    void SpawnCandy()
    {
        randomCandy = Random.Range(0, _candies.Length - 1);
        float _randomXpos = Random.Range(-8.0f, 7.0f);
        Instantiate(_candies[randomCandy], new Vector3(_randomXpos, transform.position.y, transform.position.z), Quaternion.identity);
    }
    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(_randomTime);
            _randomTime = Random.Range(2, 3);
            SpawnCandy();
        }
    }
}
