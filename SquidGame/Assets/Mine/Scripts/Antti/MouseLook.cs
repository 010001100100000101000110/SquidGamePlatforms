using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //public Vector2 tempMouse; // n‰hd‰‰n inpektorissa hiiren liikkuminen
    [SerializeField] private float mouseSpeed = 1000; // hiiren herkkyys
    private float xRotation; // m‰‰ritell‰‰n kameran liikkuminen hiiren mukaan x-akselissa, k‰‰ntyy siis x_akselin mukaan
    [SerializeField] private Transform playerTransform; //liikutetaan kamemeraa hiiren avulla sivuille (y-akselin mukaan)
    [SerializeField] private float rotateDown = -70;
    [SerializeField] private float rotateUp = 50;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lukitaan hiiri keskell‰ n‰yttˆ‰
        Cursor.visible = false; // piilotetaan hiiri kuvaruudusta
    }
 
    void Update()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;//liikutaan vasen - oikea (x-akseli), Time.deltaTime = toimii joka koneella samalla nopeudella
        float mouseVertical = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;//liikutaan ylˆs - alas (y)
        //tempMouse = new Vector2(mouseHorizontal, mouseVertical); // n‰hd‰‰n inpektorissa hiiren liikkuminen
        xRotation -= mouseVertical; // m‰‰ritet‰‰n hiiren liikkuminen ylˆs ja alas (mouseVertical)
        xRotation = Mathf.Clamp(xRotation, rotateDown, rotateUp); // m‰‰ritell‰‰n hiiren liikkumis rata ylˆs ja alas (x)
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // hiiri liikkuttaa kameraa ylˆs ja alas (k‰‰ntyy x-akselin mukaan = Quaternion.Euler(xRotation, 0, 0))
        playerTransform.Rotate(Vector3.up * mouseHorizontal); //liikutetaan kameraa y/up mukaan * hiiren mouseHorizontal  liikuttaa asteiden mukaan
    }
}
