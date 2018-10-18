using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{
    public float speed = 10.0f;

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
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
