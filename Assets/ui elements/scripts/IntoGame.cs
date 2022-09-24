using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void newScene()
    {
        SceneManager.LoadScene("Forest", LoadSceneMode.Single);
    }

    public void end()
    {
        Destroy(gameObject);
    }
}
