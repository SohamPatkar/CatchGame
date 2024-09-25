using UnityEngine;

public class CandyScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    public ControllerScript _playerLives;
    private float _destroyRange = -5;
    private void Start()
    {
        _playerLives = GameObject.Find("Player").GetComponent<ControllerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyCandy();
    }
    void DestroyCandy()
    {
        if (transform.position.y < _destroyRange)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _playerLives._lives -= 1;
            Instantiate(_collisionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
