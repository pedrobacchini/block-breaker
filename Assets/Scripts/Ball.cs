using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configure parameters
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds = null;
    [SerializeField] private float randomFactor = 0.2f;

    // State variables
    private Vector3 _paddleToBallVector;
    private bool _hasStarted = false;

    // Cached component references
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;
    private GameSession _gameSession;
    private PaddleControl paddle = null;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameSession = FindObjectOfType<GameSession>();
        paddle = FindObjectOfType<PaddleControl>();

        _gameSession.UpdateVelocity(_rigidbody2D.velocity.magnitude);
        _paddleToBallVector = transform.position - paddle.transform.position;
    }

    private void Update()
    {
        if (_hasStarted) return;
        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(xPush, yPush);
            _hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle.transform.position + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_hasStarted) return;
        TriggerSfxEffect();
        AddRandomFactorVelocity();
        _gameSession.UpdateVelocity(_rigidbody2D.velocity.magnitude);
    }

    private void AddRandomFactorVelocity()
    {
//        First solution
//        var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
//        _rigidbody2D.velocity += velocityTweak;

//        Second solution
        var randomAngle = Random.Range(-randomFactor, randomFactor);
        _rigidbody2D.velocity = Quaternion.Euler(0, 0, randomAngle) * _rigidbody2D.velocity;
    }

    private void TriggerSfxEffect()
    {
        var randomIndex = Random.Range(0, ballSounds.Length);
        _audioSource.PlayOneShot(ballSounds[randomIndex]);
    }
}