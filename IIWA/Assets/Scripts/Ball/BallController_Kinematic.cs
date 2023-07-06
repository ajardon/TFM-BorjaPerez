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

public class BallController_Kinematic : MonoBehaviour
{
    /*SAVE POSITION*/
    private float posicionx, posiciony, posicionz, wait = 0.5f, timer;
    /*SAVE POSITION*/
    private Button save;
    // public GameObject //warning;
    private bool warn;
    private int timesOut, totalOut;
    /*DESTROY BALL*/
    // public Timer ////stopClock;
    // public GameObject //panel;
    private int hour, min, sec, speed, score;
    /*DESTROY COINS*/
    public GameObject ball;
    // public Text //scoreText;
    private int effectsOn, score1;
    public AudioClip soundCoins;
    private AudioSource coins;
    /*PATHS LIMITS*/
    public AudioClip soundLimits;
    private AudioSource limits;
// -------- Borja --------------------------------------------------
    private ROSConnection ros;
    public GameObject obj;
    public Rigidbody rb;
    private Vector3 initial_pose;
    private Vector3 PosDiff = Vector3.zero;
    private Vector3 orgPos, dstPos, newPos;
    private bool isPosDiffSet = false;
    public float w_scale;// = (float)15.0;
    public float h_scale;// = (float)15.0;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<AudioSource>();
        limits = GetComponent<AudioSource>();
        //panel.gameObject.SetActive(false); 
        effectsOn = PlayerPrefs.GetInt("Effects");

        initial_pose = transform.position;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(0, 1, 0);
        //Debug.Log("INITIAL AT START " + initial_pose);
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<PoseStampedMsg>("/iiwa/id_1/ee_pose", moveObj);

    }

    void moveObj(PoseStampedMsg pose_msg)
    {
        if(isAlive){
            PoseStampedMsg aux = (PoseStampedMsg)pose_msg;
            PoseMsg robot_pose = pose_msg.pose;
            //Vector3 vpose = new Vector3((float)robot_pose.position.y * w_scale, (float)robot_pose.position.z * h_scale, 0);
            Vector3 vpose = new Vector3((float)robot_pose.position.y * w_scale, (float)robot_pose.position.z * h_scale, 0);

            if(!isPosDiffSet){
                //PosDiff = new Vector3(vpose[0] - initial_pose[0], vpose[1] - initial_pose[1], 0);
                PosDiff = new Vector3(initial_pose.x - vpose[0], initial_pose.y - vpose[1], 0);

                //Debug.Log("POSDIFF SET" + PosDiff);
                isPosDiffSet = true;
            }
            orgPos = transform.position;
            dstPos = new Vector3(vpose[0] + PosDiff.x, vpose[1] + PosDiff.y, initial_pose[2]);

            newPos = Vector3.Lerp(orgPos, dstPos, 0.2f);
            transform.position = newPos;
        }
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
            //warning.gameObject.SetActive(true);
            //Debug.Log("Activar");

        }
        else
        {
            //warning.gameObject.SetActive(false);
            //Debug.Log("desactivar");
        }

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
            ////stopClock.Pause();
            //panel.gameObject.SetActive(true);
            DesactivarAviso();
            score = PlayerPrefs.GetInt("Score");
            speed = 0;
            PlayerPrefs.SetInt("Speed", speed);
            // END ROS CONNECTION
            
        }
        else
        {
            //panel.gameObject.SetActive(false);
        }

        /*------------------DESTROY COINS-------------------*/

        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            score1++;
            //scoreText.text = score1.ToString();
            PlayerPrefs.SetInt("ScoreDinamic", score1);


            if (effectsOn == 1)
            {
                coins.PlayOneShot(soundCoins, 1.0f);
            }

        }
    }
    public void DesactivarAviso() 
    {
        //warning.gameObject.SetActive(false);
    }
}