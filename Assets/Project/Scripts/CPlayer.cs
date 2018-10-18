using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public float speed = 10.0f;
    public float sizeOffset = 0.0f;

    private Rigidbody2D _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
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

        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - sizeOffset;
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
