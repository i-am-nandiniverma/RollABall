using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class playerControl : MonoBehaviour
{
    private int count;
    public GameObject WinText;
    public TextMeshProUGUI countText;
    public float speed =0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector= movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;        
    }
    void SetCountText () {
        countText.text="Score: " + count.ToString();
        if (count>=8){
            WinText.gameObject.SetActive(true);
        }
    }
    void FixedUpdate(){
        Vector3 movement=new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Collectible")) {
            other.gameObject.SetActive(false);
            count=count+1;
            SetCountText();
        }
        
    }
}
