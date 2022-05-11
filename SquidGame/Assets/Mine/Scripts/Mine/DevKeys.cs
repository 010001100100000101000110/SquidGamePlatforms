using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevKeys : MonoBehaviour
{
    private SceneChangeMemoryGameEnd sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = FindObjectOfType<SceneChangeMemoryGameEnd>();
    }

    // Update is called once per frame
    void Update()
    {
        DevHotKeys();
    }

    private void DevHotKeys()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
        {
            sceneChange.PlayerWin();
        }
    }
}
