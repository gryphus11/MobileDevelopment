using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class CSceneManager3DSpace : MonoBehaviour
{
    public Text infoText = null;

    public CPlayer3D player = null;

    // Use this for initialization
    void Start()
    {
        LeanTouch.OnFingerTap += OnTap;
    }

    public void OnTap(LeanFinger finger)
    {
        Debug.Log("Tap!");
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "No Input Detected";

        int touchAmount = 0;
        List<Vector2> touchCoordinates = new List<Vector2>();

        foreach (Touch touch in Input.touches)
        {
            ++touchAmount;
            touchCoordinates.Add(touch.position);
        }

        #region 더미 터치 테스트
        if (Input.GetMouseButton(0))
        {
            ++touchAmount;
            touchCoordinates.Add(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ++touchAmount;
            touchCoordinates.Add(new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f)));
        }

        if (Input.GetKey(KeyCode.V))
        {
            ++touchAmount;
            touchCoordinates.Add(new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f)));
        }
        #endregion

        if (touchCoordinates.Count > 0)
        {
            infoText.text = "";
            for (int i = 0; i < touchAmount; ++i)
            {
                infoText.text += string.Format("Input {0} : {1}, {2}\n", i + 1, touchCoordinates[i].x.ToString("0.00"), touchCoordinates[i].y.ToString("0.00"));
            }
        }


        if (touchCoordinates.Count == 2)
        {
            player.ActivateSpeedUp();
        }
        else if (touchCoordinates.Count == 3)
        {
            player.ActivateInvincibility();
        }
    }
}
