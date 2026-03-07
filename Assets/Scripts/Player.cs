using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public float moveSpeed = 2f;
    
    private Vector2 _targetPosition;
    private Vector2 _currentVelocity;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        if (_rb)
        {
            _rb.linearVelocity = movement * moveSpeed;
        }
        else
        {
            transform.Translate(movement * (moveSpeed * Time.deltaTime));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D {other.gameObject.name}");
        
        /*if (other.TryGetComponent(out SpriteRenderer enemyRenderer))
        {
            enemyRenderer.color = Color.green; 
        } */
        
        Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
        Color enemyColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        Renderer.color = enemyColor;
        other.gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        
        Debug.Log($"The player is {enemyColor}");
        Debug.Log($"The enemy is {playerColor}");
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log($"OnTriggerStay2D {other.gameObject.name}");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"OnTriggerExit2D {other.gameObject.name}");
        
        
        Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
        Color enemyColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        Renderer.color = enemyColor;
        other.gameObject.GetComponent<SpriteRenderer>().color = playerColor;
        
        Debug.Log($"The player is {enemyColor}");
        Debug.Log($"The enemy is {playerColor}");
        
    }
}

