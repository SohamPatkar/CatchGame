using UnityEngine;

public class ControllerScript : PlayerStats
{
    private float InputXaxis, _speed;
    private Rigidbody2D _playerRigidBody;
    public int _lives, _score;
    private float _maxLeft, _maxRight;
    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void InitializeVariables()
    {
        _maxLeft = -8.0f;
        _maxRight = 7.85f;
        _lives = base.Lives;
        _score = base.Score;
        _speed = 8.5f;
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Movement()
    {
        InputXaxis = Input.GetAxis("Horizontal");
        // _playerRigidBody.AddForce(new Vector2(InputXaxis * Time.deltaTime * _speed, transform.position.y), ForceMode2D.Impulse);

        transform.position += Vector3.right * InputXaxis * _speed * Time.deltaTime;
        if (transform.position.x > _maxRight)
        {
            transform.position = new Vector2(_maxRight, transform.position.y);
        }
        else if (transform.position.x < _maxLeft)
        {
            transform.position = new Vector2(_maxLeft, transform.position.y);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Collectibles"))
        {
            if (_score == 0)
            {
                _score = 0;
            }
            _score += 1;
            Destroy(other.gameObject);
        }
    }
}
