using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardTest : MonoBehaviour
{
    public GameObject Key_A;
    public GameObject Key_D;
    public GameObject Key_Space;
    public GameObject Key_J;
    public GameObject Key_K;
    public GameObject Key_L;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Key_A.SetActive(Input.GetKey(KeyCode.A));
        Key_D.SetActive(Input.GetKey(KeyCode.D));
        Key_Space.SetActive(Input.GetKey(KeyCode.Space));
        Key_J.gameObject.SetActive(Input.GetKey(KeyCode.J));
        Key_K.gameObject.SetActive(Input.GetKey(KeyCode.K));
        Key_L.gameObject.SetActive(Input.GetKey(KeyCode.L));
    }
}
