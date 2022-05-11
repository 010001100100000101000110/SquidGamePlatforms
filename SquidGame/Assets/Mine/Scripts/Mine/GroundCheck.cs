using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour
{
    //private GameManager gameManager;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private bool hasHitBP;
    // Start is called before the first frame update
    void Start()
    {
        hasHitBP = false;
    }

    // Update is called once per frame
    void Update()
    {
         Collider[] hitObjects = Physics.OverlapSphere(groundCheck.position, 0.4f);

        for (int i = 0; i < hitObjects.Length; i++)

        {
            if (hitObjects[i].transform.CompareTag("BP") && hasHitBP == false)
            {
                hasHitBP = true;
                //gameManager.PlayerLose();
            }
        }


    }

}
