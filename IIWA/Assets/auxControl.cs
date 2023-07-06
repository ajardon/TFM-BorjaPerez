using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxControl : MonoBehaviour
{
    Vector3[] edges = new Vector3[4];
    public Rigidbody rb;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("tpSquare", 1.0f, 1.0f);
        //InvokeRepeating("moveSquare", 1.0f, 1.0f);
        edges[0] = Vector3.up;
        edges[1] = Vector3.right;
        edges[2] = Vector3.down;
        edges[3] = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dstPos = this.transform.position;
        switch(count){
            case 0:
                rb.AddForce(edges[0] * 20f);
                count += 1;
                break;
            case 1:
                rb.AddForce(edges[1] * 20f);
                count += 1;
                break;
            case 2:
                rb.AddForce(edges[2] * 20f);
                count += 1;
                break;
            case 3:
                rb.AddForce(edges[3] * 20f);
                count-=3;
                break;
        }
    }

    void tpSquare(){
        switch(count){
            case 0:
                this.transform.position = edges[0];
                count += 1;
                break;
            case 1:
                this.transform.position = edges[1];
                count += 1;
                break;
            case 2:
                this.transform.position = edges[2];
                count += 1;
                break;
            case 3:
                this.transform.position = edges[3];
               count-=3;
               break;
        }
    }

    void moveSquare(){
        Vector3 dstPos = this.transform.position;
        switch(count){
            case 0:
                dstPos = Vector3.Lerp(this.transform.position, edges[0], 0.5f);
                rb.MovePosition(dstPos);
                count += 1;
                break;
            case 1:
                dstPos = Vector3.Lerp(this.transform.position, edges[1], 0.5f);
                rb.MovePosition(dstPos);
                count += 1;
                break;
            case 2:
                dstPos = Vector3.Lerp(this.transform.position, edges[2], 0.5f);
                rb.MovePosition(dstPos);
                count += 1;
                break;
            case 3:
                dstPos = Vector3.Lerp(this.transform.position, edges[3], 0.5f);
                rb.MovePosition(dstPos);
                count-=3;
                break;
        }
    }
}
