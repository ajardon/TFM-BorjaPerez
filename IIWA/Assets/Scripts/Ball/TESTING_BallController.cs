using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING_BallController : MonoBehaviour
{
    private Rigidbody rigidB;
    // private int speed = 10;
    private Vector3 newPos;

    void Start(){
        rigidB = GetComponent<Rigidbody>();
    }

    void Update () {
        Vector3 orgPos = transform.localPosition;

        if (Input.GetKey(KeyCode.UpArrow)) {
            //rigidB.AddForce(Vector3.up * speed);
            newPos = Vector3.Lerp(orgPos, orgPos + Vector3.up/10, 1);
            rigidB.MovePosition(newPos);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            //rigidB.AddForce(Vector3.down * speed);
            newPos = Vector3.Lerp(orgPos, orgPos + Vector3.down/10, 1);
            rigidB.MovePosition(newPos);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            //rigidB.AddForce(Vector3.right *speed);
            newPos = Vector3.Lerp(orgPos, orgPos + Vector3.right/10, 1);
            rigidB.MovePosition(newPos);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            //rigidB.AddForce(Vector3.left *speed);
            newPos = Vector3.Lerp(orgPos, orgPos + Vector3.left/10, 1);
            rigidB.MovePosition(newPos);
        }
        else{
            rigidB.AddForce(Vector3.zero);
            Debug.Log("No Key Pressed");
        }
        
    }

}