using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
   [SerializeField]private float _jumpForce = 9f;
    private Vector2 _startPos;
    private bool _isGrounded;
    [SerializeField] private Animator _anim;
    

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

   private void OnEnable()
   {
      _startPos = Vector2.zero;
   }

    // Update is called once per frame
    void Update()
    {
        if (_isGrounded)
        {
            Jump();
            // Yerde ise zýpla
        }

        isBending();
        
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
            _rb.velocity = Vector2.up * _jumpForce;
            _isGrounded = false;
            // havada olduðunu belirtiyor.
        }                                  
 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            // Yere temasý
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Score Increase");
        }
    }
}
