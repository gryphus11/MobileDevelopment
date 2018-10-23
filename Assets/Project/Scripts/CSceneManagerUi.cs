using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManagerUi : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("3DSpace");
    }
}
