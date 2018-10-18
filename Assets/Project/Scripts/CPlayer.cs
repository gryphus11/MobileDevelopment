using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D _rigidbody = null;
    private SpriteRenderer _renderer = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis < 0)
        {
            _rigidbody.velocity = new Vector2(-speed, 0);
        }
        else if (hAxis > 0)
        {
            _rigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 relativeMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
                if (relativeMousePosition.x < 0.5f)
                {
                    _rigidbody.velocity = new Vector2(-speed, 0);
                }
                else if (relativeMousePosition.x > 0.5f)
                {
                    _rigidbody.velocity = new Vector2(speed, 0);
                }
            }
            else
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }

        float spriteHalfWidth = _renderer.sprite.bounds.size.x * 0.5f;
        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - spriteHalfWidth;
        //float screenLimit = (Camera.main.orthographicSize * (4.0f / 3.0f)) - spriteHalfWidth;
        if (transform.position.x > screenLimit)
        {
            transform.position = new Vector3(screenLimit, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -screenLimit)
        {
            transform.position = new Vector3(-screenLimit, transform.position.y, transform.position.z);
        }
    }
}
