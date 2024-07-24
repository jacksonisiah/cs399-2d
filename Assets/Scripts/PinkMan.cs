using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinkMan : MonoBehaviour
{
    [SerializeField] protected float walkSpeed = 100f; // 100 meters

    // Jump force
    [SerializeField] protected float jumpForce = 100f;

    private Animator _anim;

    // Apple tag
    private readonly string _appleTag = "Apple";

    private bool _enableAirJump;

    // Default character facing direction
    private bool _faceRight = true;

    // Boolean varible to check if the character is on the ground
    private bool _grounded;

    private Rigidbody2D _rb;

    // Boolean varible to check if the character is running
    private bool _run;

    // A counter used to trigger running
    private int _runCounter;

    private GameObject _scoreboard;

    // Spike tag
    private readonly string _spikeTag = "Spikes";

    // The integer value for the Terrain layer
    private int _terrainLayer;

    protected float RunSpeed;

    public int ItemsCount { get; set; }

    // Number of character lives, default to 3 
    public int Lives { get; set; } = 3;

    public int LivesLost { get; set; }

    //
    private void Awake()
    {
        Application.targetFrameRate = -1;
        _terrainLayer = LayerMask.NameToLayer("Terrain");
    }

    // Start is called before the first frame update
    private void Start()
    {
        RunSpeed = 3 * walkSpeed;
        // Get references in the scene
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _scoreboard = GameObject.Find("Scoreboard");
        _scoreboard.SendMessage("Toggle");
        // Load lives from PlayerPrefs, default lives to 3 if the entry does not exist
        Lives = PlayerPrefs.GetInt("Lives",3);
        Lives = 3;
    }

    // Update is called once per frame
    private void Update()
    {
        // Handles both keyboard and joystick
        var jump = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump");

        if (jump)
        {
            if (_grounded)
            {
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                _grounded = false;
                _enableAirJump = true;
            }
            else if (_enableAirJump)
            {
                _rb.AddForce(Vector2.up * 200, ForceMode2D.Force);
                _enableAirJump = false;
            }
        }

        // Restart level
        if (Lives == 0)
        {
            RestartLevel(); 
        }
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        // Move horizontally
        var hMove = Input.GetAxis("Horizontal");
        var speed = walkSpeed;
        if (_run)
            speed = RunSpeed;

        // Update character velocity
        _rb.velocity = new Vector2(hMove * speed * Time.deltaTime, _rb.velocity.y);

        /* Change character face direction*/
        // Face left
        if (hMove < 0 && _faceRight)
        {
            _rb.transform.Rotate(0f, 180f, 0, Space.Self);
            _faceRight = false;
        }

        // Face right
        if (hMove > 0 && !_faceRight)
        {
            _rb.transform.Rotate(0f, 180f, 0, Space.Self);
            _faceRight = true;
        }

        // Set walk animation
        if (hMove == 0)
            _anim.SetBool("walk", false);
        else
            _anim.SetBool("walk", true);

        // Switch to run animation
        if (Math.Abs(hMove) == 1)
        {
            if (_runCounter == 3)
            {
                _run = true;
                _anim.SetBool("run", true);
            }

            _runCounter++;
        }
        else
        {
            _run = false;
            _anim.SetBool("run", false);
            _runCounter = 0;
        }
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    // Prevent air jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _terrainLayer)
        {
            _grounded = true;
            Debug.Log("OnCollisionEnter2D: " + collision.gameObject.layer);
        }

        if (collision.gameObject.tag == _spikeTag)
        {
            // Push the character to the opposite direction
            if (_faceRight)
                _rb.AddForce(Vector2.left * 5000);
            else
                _rb.AddForce(Vector2.right * 5000);

            // Reduce player life by one
            Lives--;
            LivesLost++;

            // Update player lives
            PlayerPrefs.SetInt("Lives", Lives);
        }

        // Update item count
        if (collision.gameObject.tag == _appleTag)
        {
            ItemsCount++;

            // Remove item
            Destroy(collision.gameObject);

            // Update lives count
            if (ItemsCount == 10)
            {
                Lives++;
                // Update player lives
                PlayerPrefs.SetInt("Lives", Lives);
            }
        }
    }

    // OnCollisionExit2D is called when this collider2D/rigidbody2D has stopped touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("OnCollisionExit2D: " + collision.gameObject.name);
    }

    private void RestartLevel()
    {
        // Load the current scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Lives", 3);
    }
}