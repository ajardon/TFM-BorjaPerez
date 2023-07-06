using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Globalization;
using UnityEngine.EventSystems;
using System;

//Borja
using RosMessageTypes.Geometry;
using RosMessageTypes.UnityRoboticsDemo;
using ROSGeometryMsgs = RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector;

using PoseMsg = RosMessageTypes.Geometry.PoseMsg;
using PoseStampedMsg = RosMessageTypes.Geometry.PoseStampedMsg;
using PointMsg = RosMessageTypes.Geometry.PointMsg;
using CollMsg = RosMessageTypes.Roboasset.CollisionPointMsg;
using ControlModeServiceRequest = RosMessageTypes.Roboasset.ControlModeServiceRequest;
using ControlModeServiceResponse = RosMessageTypes.Roboasset.ControlModeServiceResponse;

public class BallController : MonoBehaviour
{
    /*SAVE POSITION*/
    private float posicionx, posiciony, posicionz, wait = 0.5f, timer;
    /*SAVE POSITION*/
    private Button save;
    public GameObject warning;
    private bool warn;
    private int timesOut, totalOut;
    /*DESTROY BALL*/
    public Timer stopClock;
    public GameObject panel;
    private int hour, min, sec, speed, score;
    /*DESTROY COINS*/
    public GameObject ball;
    public Text scoreText;
    private int effectsOn, score1;
    public AudioClip soundCoins;
    private AudioSource coins;
    /*PATHS LIMITS*/
    public AudioClip soundLimits;
    private AudioSource limits;
// -------- Borja --------------------------------------------------
    private ROSConnection ros;
    //private ROSConnection sub;
    //private ROSConnection pub;
    //private ROSConnection srv;
    public GameObject obj;
    public GameObject kinemBall;
    private Rigidbody rb;
    private Vector3 initial_pose;
    private Vector3 PosDiff = Vector3.zero;
    private Vector3 orgPos, dstPos, newPos;
    private bool isPosDiffSet = false;
    public float w_scale = (float)17.0;
    public float h_scale = (float)15.0;
    private Vector3 coll_norm;
    private Vector3 coll_point;
    private bool onCollision = false;
    PoseMsg robot_pose;
    //public GameObject PathLimits;
    //public Collider[] mazeColliders;
    //public LayerMask wallLayer;
    public float rayDistance = 0.1f;
    public float forceMagnitude = 0.0001f;
    public float collisionThreshold = 0.01f;
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = kinemBall.transform.position;
        coins = GetComponent<AudioSource>();
        limits = GetComponent<AudioSource>();
        panel.gameObject.SetActive(false); 
        effectsOn = PlayerPrefs.GetInt("Effects");

        initial_pose = transform.position;
        rb = GetComponent<Rigidbody>();

        ros = ROSConnection.GetOrCreateInstance();

        // Debug.Log("REGISTRAMOS TODO");
        ros.RegisterPublisher<CollMsg>("/iiwa/id_1/collision_point");
        //ros.Subscribe<PoseStampedMsg>("/iiwa/id_1/ee_pose", moveObj);
        ros.Subscribe<PoseStampedMsg>("/iiwa/id_1/ee_pose", moveObj);
        ros.RegisterRosService<ControlModeServiceRequest, ControlModeServiceResponse>("/iiwa/id_1/set_control_mode");
        ControlModeServiceRequest cmServiceRequest = new ControlModeServiceRequest(7, "100111");
        ros.SendServiceMessage<ControlModeServiceResponse>("/iiwa/id_1/set_control_mode", cmServiceRequest, callback);
        
        //mazeColliders = PathLimits.GetComponentsInChildren<MeshCollider>();
        rb = GetComponent<Rigidbody>();
        Debug.Log("Time.deltaTime = " + Time.deltaTime);

        PosDiff = new Vector3(transform.position.x - kinemBall.transform.position.x, transform.position.y - kinemBall.transform.position.y, 0);
    }

    void callback(ControlModeServiceResponse response)
    {
        Debug.Log("Service Response: " + response);
    }

    void moveObj(PoseStampedMsg poseStamped_msg)
    {
        //Debug.Log("POSESTAMPED RECIBIDA " + poseStamped_msg);
        //Debug.Log("POSE RECIBIDA " + poseStamped_msg.pose);
        Vector3 offset = new Vector3(0.0f, 0.15f, 0.0f);
        if(true){ //isAlive
            PoseStampedMsg aux = (PoseStampedMsg)poseStamped_msg;
            robot_pose = aux.pose;
            Vector3 vpose = new Vector3((float)robot_pose.position.y * w_scale, (float)robot_pose.position.z * h_scale, 0);
            if(!isPosDiffSet){
                initial_pose = transform.position;
                //Debug.Log("PosDiff es " + vpose[0] + " - " + initial_pose[0] + " = " + (vpose[0] - initial_pose[0]));
                Debug.Log("PosDiff es " + initial_pose.x + " - " + vpose[0] + ", " + initial_pose.y + " - " + vpose[1] + ", 0");
                PosDiff = new Vector3(initial_pose.x - vpose[0], initial_pose.y - vpose[1], 0);
                
                //Debug.Log("POSDIFF SET" + PosDiff);
                isPosDiffSet = true;
            }
            orgPos = transform.position;
            Vector3 orgV = orgPos + offset;

            //dstPos = new Vector3(vpose[0] + PosDiff[0] * w_scale, vpose[1] + PosDiff[1] * h_scale, initial_pose[2]);
            dstPos = kinemBall.transform.position;
            Vector3 dstV = dstPos + offset;

            Vector3 dirVector = dstV - orgV;
            //dirVector.Normalize();
            Debug.DrawLine(orgV, dstV, new Color(1.0f, 0.0f, 0.0f));
            RaycastHit hitInfo;
            if(Physics.Raycast(orgV, dirVector, out hitInfo, dirVector.magnitude))
            {
                onCollision = true;
                Debug.Log("ON COLIISION WITH RAYCAST");
                dstPos = hitInfo.point;
            }
            else{
                onCollision = false;
            }

            newPos = Vector3.Lerp(orgPos, dstPos, 0.5f);
            rb.MovePosition(newPos);
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Touchable"){
            Debug.Log("Colisionando con objeto " + collision.gameObject.name);
            onCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision){

        if (collision.gameObject.tag == "Touchable"){
            Debug.Log("Se ha salido de la colision con objeto " + collision.gameObject.name);
            onCollision = false;
        }
    }

    // private bool IsInsideMaze(Vector3 point){
    //     // lanzar un rayo hacia abajo desde el punto
    //     Ray ray = new Ray(point, Vector3.down);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit, rayDistance, wallLayer))
    //     {
    //         Debug.Log("INSIDE");
    //         // el rayo interseca con el laberinto, por lo que la bola está dentro del laberinto
    //         return true;
    //     }
    //     else
    //     {
    //         Debug.Log("OUTSIDE");
    //         // el rayo no interseca con el laberinto, por lo que la bola está fuera del laberinto
    //         return false;
    //     }
    // }

    // private Vector3 FindClosestPoint(Vector3 point)
    // {
    //     Vector3 closestPoint = Vector3.zero;
    //     float minDistance = float.MaxValue;
    //     Collider closestCollider = null;

    //     foreach (Collider collider in mazeColliders)
    //     {
    //         Vector3 colliderClosestPoint = collider.ClosestPoint(point);
    //         float distance = Vector3.Distance(point, colliderClosestPoint);
    //         //Debug.Log("Checking collider " + collider + " with distance of " + distance);
    //         if (distance < minDistance)
    //         {
    //             closestPoint = colliderClosestPoint;
    //             closestCollider = collider;
    //             minDistance = distance;
    //         }
    //     }
    //     //Debug.Log("Closest Collider from " + point + " is " + closestCollider + " with the closest point at " + closestPoint + " with distance of " + minDistance);
    //     return closestPoint;
    // }

    void Update()
    {
        // Vector3 offset = new Vector3(0.0f, 0.15f, 0.0f);
        // orgPos = transform.position;
        // Vector3 orgV = orgPos + offset;

        // //dstPos = new Vector3(vpose[0] + PosDiff[0] * w_scale, vpose[1] + PosDiff[1] * h_scale, initial_pose[2]);
        // dstPos = kinemBall.transform.position;
        // Vector3 dstV = dstPos + offset;

        // Vector3 dirVector = dstV - orgV;
        // Debug.DrawLine(orgV, dstV, new Color(1.0f, 0.0f, 0.0f));
        // RaycastHit hitInfo;
        // if(Physics.Raycast(orgV, dirVector, out hitInfo, dirVector.magnitude))
        // {
        //     onCollision = true;
        //     Debug.Log("ON COLIISION WITH RAYCAST");
        //     dstPos = hitInfo.point;
        // }
        // else{
        //     onCollision = false;
        // }

        // newPos = Vector3.Lerp(orgPos, dstPos, 0.5f);
        // rb.MovePosition(newPos);
        
        // Color color_dist = new Color(1.0f, 0.0f, 0.0f); // red
        //Debug.DrawLine(this.transform.position, kinemBall.transform.position, color_dist);
        /*-----------------SAVE POSITION------------------*/
        timer += Time.deltaTime;
        if (timer >= wait)
        {
            posicionx = ball.transform.position.x;
            posiciony = ball.transform.position.y;
            posicionz = ball.transform.position.z;
            timer = 0.0f;
        }

        /*------------------PATH LIMITS-------------------*/
        PlayerPrefs.SetInt("VecesFuera", totalOut);

        if (warn == true)
        {
            warning.gameObject.SetActive(true);
            //Debug.Log("Activar");

        }
        else
        {
            warning.gameObject.SetActive(false);
            //Debug.Log("desactivar");
        }

        // PointMsg contactPoint = new PointMsg(
        //     dstPos.x,
        //     dstPos.y,
        //     dstPos.z
        // );
        // PointMsg contactPoint = new PointMsg(
        //     robot_pose.position.x, 
        //     (orgPos.x - PosDiff.x)/w_scale,
        //     (orgPos.y - PosDiff.y)/h_scale
        // );
        if(isPosDiffSet){
            PointMsg contactPoint = new PointMsg(
                robot_pose.position.x, 
                (this.transform.position.x - PosDiff.x)/w_scale,
                (this.transform.position.y - PosDiff.y)/h_scale
            );
            //HACER TRANSFORMACIÓN POS-UNITY A POS-IIWA
            CollMsg collPoint = new CollMsg(
                onCollision,
                contactPoint
            );

            Debug.Log("COLISION? " + onCollision);
            ros.Publish("/iiwa/id_1/collision_point", collPoint);
            /*------------------DESTROY BALL-------------------*/
            Debug.Log("ArmPos: " + robot_pose.position + "\nPlayerBall: " + orgPos + "\nPossDiff: " + PosDiff + "\nSentPos: " + contactPoint);
        }
        // Debug.Log("Oper: " + orgPos.z + " - " + PosDiff.z + " = " + (orgPos.z - PosDiff.z) + "\n" + orgPos.x + " - " + PosDiff.x + " = " + ((orgPos.x - PosDiff.x)/w_scale) + "\n" + orgPos.y + " - " + PosDiff.y + " = " + ((orgPos.y - PosDiff.y)/h_scale));
        // robot_pose -> posicion real recibida del robot en crudo (sin transformar)
        // orgPos -> posicion jugador ANTES de movimiento
        // PosDiff -> vector de transformación calculado en primera instancia (diferencia entre pos inicial jugador y pos inicial recibida del robot en crudo)
        // contactPoint -> punto XYZ de colisión (debería ser la posición objetivo del jugador)
        // Alomejor como contactPoint es en la pared, habría que restar el radio del collider del jugador multiplicado por el vector dirección colisión inverso para
        // que la posición objetivo del jugador sea una posición alcanzable

    }
    private void OnTriggerEnter(Collider other)
    {
        
        /*if (other.CompareTag("Path"))
        {
            warn = true;
            timesOut++;
            totalOut = timesOut / 2;

            if (effectsOn == 1)
            {
                limits.PlayOneShot(soundLimits, 1.0f);
            }
        }
        else
        {
            warn = false;
        }
        */

        //if(other.CompareTag("Limits")){
            //Debug.Log("OUT OF LIMITS\nCollision on (" + other.point.x + ", " + other.point.y + ", ", other.point.z + ")");
        //}

        /*------------------DESTROY BALL-------------------*/
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
            stopClock.Pause();
            panel.gameObject.SetActive(true);
            DesactivarAviso();
            score = PlayerPrefs.GetInt("Score");
            speed = 0;
            PlayerPrefs.SetInt("Speed", speed);
            // END ROS CONNECTION
            
        }
        else
        {
            panel.gameObject.SetActive(false);
        }

        /*------------------DESTROY COINS-------------------*/

        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            score1++;
            scoreText.text = score1.ToString();
            PlayerPrefs.SetInt("ScoreDinamic", score1);


            if (effectsOn == 1)
            {
                coins.PlayOneShot(soundCoins, 1.0f);
            }

        }
    }
    public void DesactivarAviso() 
    {
        warning.gameObject.SetActive(false);
    }
}
   
