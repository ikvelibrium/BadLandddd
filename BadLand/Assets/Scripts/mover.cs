using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mover : MonoBehaviour
{

    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _hSpeed;
    [SerializeField] private float _vSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _checkRadius;
    [SerializeField] private float _speedPotionActionTime; // переменные отвечающие за максимальное время действия обилок 
    [SerializeField] private float _scalePotionActionTime; // переменные отвечающие за максимальное время действия обилок 
    public static int lvlCounter = 0;

    

    private bool _isSpeedPotionCollected; 
    private bool _isScalePOtionCollected;

    private float _speedPotionTime; // переменные отвечающие за текущее время действия обилок 
    private float _scalePotionTime;


    private bool _grounded;

    private void Start()
    {
        lvlCounter = PlayerPrefs.GetInt("LVLCounter", lvlCounter);
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * _horizontalInput * _hSpeed * Time.deltaTime);
        if(Input.GetButton("Jump"))
        {
            rb.velocity = Vector2.up * _vSpeed;
        }
        _grounded = Physics2D.OverlapCircle(_groundChecker.position, _checkRadius, _ground);
        Vector3 vRotation = new Vector3(1, 1, 1);
        
        if ( _grounded == false)
        {
            rb.MoveRotation(vRotation.x);
        }
       
        if (_speedPotionTime > 0)
        {
            _speedPotionTime -= Time.deltaTime;
        }
        if (_scalePotionTime > 0)
        {
            _scalePotionTime -= Time.deltaTime;
        }
        if (_speedPotionTime <= 0 && _isSpeedPotionCollected == true)
        {
            
            _hSpeed = 2;
            _isSpeedPotionCollected = false;
        }
        if (_scalePotionTime <= 0 && _isScalePOtionCollected == true)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            _isScalePOtionCollected = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7) // Scale potion
        {

            gameObject.transform.localScale = new Vector3(2, 2, 2);
            _scalePotionTime += _scalePotionActionTime;
            _isScalePOtionCollected = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 8) // Speed potion
        {
            
            _hSpeed = 5;
            _isSpeedPotionCollected = true;
            _speedPotionTime += _speedPotionActionTime;
            Destroy(collision.gameObject);
        } 
        if(collision.gameObject.layer == 9)
        {
            lvlCounter++;
            PlayerPrefs.SetInt("LVLCounter", lvlCounter);
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("lol you died");
            
            SceneManager.LoadScene(0);
        }
    }
}
