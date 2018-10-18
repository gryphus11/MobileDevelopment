using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CPlayer3D : MonoBehaviour
{
    public float speed = 0.0f;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 relativeMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

            if (relativeMousePosition.x < 0.5f)
            {
                _rigidbody.velocity = new Vector3(-speed, 0.0f, 0.0f);
            }
            else if (relativeMousePosition.x > 0.5f)
            {
                _rigidbody.velocity = new Vector3(speed, 0.0f, 0.0f);
            }
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
