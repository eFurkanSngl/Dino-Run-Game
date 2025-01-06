using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
   [SerializeField]private float _jumpForce = 9f;
   // private Vector2 _startPos;
    private bool _isGrounded;
    [SerializeField] private Animator _anim;
    private bool _isJumping = false;
    public static event UnityAction OnGameOver;
    
    
    

    // Start is called before the first frame update
    void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if(_rb == null)
        {
            Debug.Log("Empty");
        }
    }



    // Update is called once per frame
    void Update()
    {
        isBending();
        if (_isGrounded)
        {
            Jump();
            // Yerde ise zýpla
        }
       

    }

    private void FixedUpdate()
    {

        if (_isJumping)
        {
            _rb.gravityScale = 5f;
        }

    }

    private void isBending()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _anim.SetBool("isBending",true);
        }
        else
        {
            _anim.SetBool("isBending", false);

            
        }
    }

    private void Jump()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isGrounded = false;
            // havada olduðunu belirtiyor.
            _isJumping=true;
            
        }                                  
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
       else  if (collision.gameObject.CompareTag("Obstacle"))
       {
            Debug.Log("Player obstacle");
            OnGameOver?.Invoke();
            //GameManager.Instance.GameOver();
       }

    }
   

  
}
