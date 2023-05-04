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
using PointMsg = RosMessageTypes.Geometry.PointMsg;
using CollMsg = RosMessageTypes.RosIiwaUnity.CollisionPointMsg;
using ControlModeServiceRequest = RosMessageTypes.RosIiwaUnity.ControlModeServiceRequest;
using ControlModeServiceResponse = RosMessageTypes.RosIiwaUnity.ControlModeServiceResponse;

public class BallController : MonoBehaviour
{
    /*SAVE POSITION*/
    private float posicionx, posiciony, posicionz, wait = 0.5f, timer;
    private string name;
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
    private ROSConnection sub;
    private ROSConnection pub;
    private ROSConnection srv;
    public GameObject obj;
    public GameObject kinemBall;
    private Rigidbody rb;
    private Vector3 initial_pose;
    private Vector3 PosDiff = Vector3.zero;
    private Vector3 orgPos, dstPos, newPos;
    private bool isPosDiffSet = false;
    public float w_scale = (float)17.0;
    public float h_scale = (float)15.0;
    private bool isAlive = true;
    private Vector3 coll_norm;
    private Vector3 coll_point;
    private bool onCollision = false;
    public GameObject PathLimits;
    public Collider[] mazeColliders;
    public LayerMask wallLayer;
    public float rayDistance = 0.1f;
    public float forceMagnitude = 0.0001f;
    public float collisionThreshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<AudioSource>();
        limits = GetComponent<AudioSource>();
        panel.gameObject.SetActive(false); 
        effectsOn = PlayerPrefs.GetInt("Effects");

        initial_pose = transform.position;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(0, 1, 0);
        //Debug.Log("INITIAL AT START " + initial_pose);
        sub = ROSConnection.GetOrCreateInstance();
        pub = ROSConnection.GetOrCreateInstance();
        srv = ROSConnection.GetOrCreateInstance();
        
        //srv.RegisterRosService<ControlModeServiceRequest, ControlModeServiceResponse>("/iiwa/id_1/set_control_mode");
        //ControlModeServiceRequest modeServiceRequest = new ControlModeServiceRequest(7, "CONTROL_POINT_HAPTIC");
        //srv.SendServiceMessage<ControlModeServiceResponse>("/iiwa/id_1/set_control_mode", modeServiceRequest, callback);

        sub.Subscribe<PoseMsg>("/iiwa/id_1/ee_pose", moveObj);
        //pub.RegisterPublisher<CollMsg>("/iiwa/id_1/collision_point");
        
        mazeColliders = PathLimits.GetComponentsInChildren<MeshCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void callback(ControlModeServiceResponse response){

    }

    void moveObj(PoseMsg pose_msg)
    {
        Debug.Log("POSE RECIBIDA " + pose_msg);
        if(true){ //isAlive
            PoseMsg robot_pose = (PoseMsg)pose_msg;
            Vector3 vpose = new Vector3((float)robot_pose.position.y * w_scale, (float)robot_pose.position.z * h_scale, 0);
            if(!isPosDiffSet){
                initial_pose = transform.position;
                //Debug.Log("PosDiff es " + vpose[0] + " - " + initial_pose[0] + " = " + (vpose[0] - initial_pose[0]));
                PosDiff = new Vector3(initial_pose[0] - vpose[0], initial_pose[1] - vpose[1], 0);
                //Debug.Log("POSDIFF SET" + PosDiff);
                isPosDiffSet = true;
            }
            orgPos = transform.position;

            dstPos = new Vector3(vpose[0] + PosDiff[0], vpose[1] + PosDiff[1], initial_pose[2]);
            Vector3 dirVector = dstPos - orgPos;
            dirVector.Normalize();

            RaycastHit hitInfo;
            if(Physics.Raycast(orgPos, dirVector, out hitInfo, dirVector.magnitude))
            {
                dstPos = hitInfo.point;
            }

            newPos = Vector3.Lerp(orgPos, dstPos, 2f * Time.deltaTime);
            rb.MovePosition(newPos);

            Vector3 real_pos = kinemBall.transform.position;

            Vector3 direction = orgPos - real_pos;
            float distance = direction.magnitude;
            float maxDistance = 100f;
            float distanceFactor = Mathf.Clamp01(1f - distance / maxDistance);
            float proportion = 1.0f;
            Vector3 force_v = direction.normalized * distanceFactor * proportion;
            
            Debug.Log("FUERZA: " + force_v.ToString());

            Color color_dist = new Color(0.0f, 0.0f, 1.0f); // blue
            Debug.DrawLine(real_pos, real_pos + force_v, color_dist);

            // Obtener vector fuerza y enviar a topic "/fb_force"
            //PointMsg force_msg = new PointMsg(
            //    force_v.z,
            //    force_v.x,
            //    force_v.y
            //    );
            

            // Last collision direction normal
            //coll_norm = collision.contacts[0].normal;
            //coll_point = collision.contacts[0].point;
            //pub.Publish("fb_force", force_msg);
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Touchable"){
            onCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision){
        onCollision = false;
    }

    private bool IsInsideMaze(Vector3 point)
    {
        // lanzar un rayo hacia abajo desde el punto
        Ray ray = new Ray(point, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, wallLayer))
        {
            Debug.Log("INSIDE");
            // el rayo interseca con el laberinto, por lo que la bola está dentro del laberinto
            return true;
        }
        else
        {
            Debug.Log("OUTSIDE");
            // el rayo no interseca con el laberinto, por lo que la bola está fuera del laberinto
            return false;
        }
    }

    private Vector3 FindClosestPoint(Vector3 point)
    {
        Vector3 closestPoint = Vector3.zero;
        float minDistance = float.MaxValue;
        Collider closestCollider = null;

        foreach (Collider collider in mazeColliders)
        {
            Vector3 colliderClosestPoint = collider.ClosestPoint(point);
            float distance = Vector3.Distance(point, colliderClosestPoint);
            //Debug.Log("Checking collider " + collider + " with distance of " + distance);
            if (distance < minDistance)
            {
                closestPoint = colliderClosestPoint;
                closestCollider = collider;
                minDistance = distance;
            }
        }
        //Debug.Log("Closest Collider from " + point + " is " + closestCollider + " with the closest point at " + closestPoint + " with distance of " + minDistance);
        return closestPoint;
    }

    void Update()
    {
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

        PointMsg contactPoint = new PointMsg(
            this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z
        );

        CollMsg collPoint = new CollMsg(
            onCollision,
            contactPoint
        );

        //pub.Publish("/iiwa/id_1/collision_point", collPoint);
        /*------------------DESTROY BALL-------------------*/
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
            isAlive = false;
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
   
