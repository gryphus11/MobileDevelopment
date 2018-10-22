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

        float zDistance = transform.position.z - Camera.main.transform.position.z;
        zDistance = zDistance / (Mathf.Cos(Camera.main.transform.localEulerAngles.x * Mathf.Deg2Rad));

        Vector3 leftLimitVector = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, zDistance));
        Vector3 rightLimitVector = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, zDistance));

        float leftLimit = leftLimitVector.x;
        float rightLimit = rightLimitVector.x;

        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
    }
}
