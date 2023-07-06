using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using PoseMsg = RosMessageTypes.Geometry.PoseMsg;


public class RosSubscriberExample : MonoBehaviour
{
    public GameObject obj;
    public Vector3 initial_pose;
    public Vector3 PosDiff = Vector3.zero;
    public bool isPosDiffSet = false;
    public float w_scale = (float)17.0;
    public float h_scale = (float)15.0;
    public ROSConnection rs;

    void Start()
    {
        initial_pose = obj.transform.position;
        Debug.Log("INITIAL AT START " + initial_pose);
        rs.Subscribe<PoseMsg>("/iiwa/id_2/ee_pose", moveObj);
    }

    void moveObj(PoseMsg pose_msg)
    {
        PoseMsg robot_pose = (PoseMsg)pose_msg;
        Vector3 vpose = new Vector3( (float)robot_pose.position.y * w_scale, (float)robot_pose.position.z * h_scale, 0);
        if(!isPosDiffSet){
            //Debug.Log("PosDiff es " + vpose[0] + " - " + initial_pose[0] + " = " + (vpose[1] - initial_pose[0]));
            PosDiff = new Vector3(vpose[0] - initial_pose[0], vpose[1] - initial_pose[1], 0);
            //Debug.Log("POSDIFF SET" + PosDiff);
            isPosDiffSet = true;
        }
        obj.transform.position = new Vector3(vpose[0] - PosDiff[0], vpose[1] - PosDiff[1], initial_pose[2]);
        //obj.transform.rotation = new Quaternion(-(float)robot_pose.orientation.x, (float)robot_pose.orientation.y, -(float)robot_pose.orientation.z, (float)robot_pose.orientation.w);
        //Debug.Log("Estoy haciendo que " + vpose[0] + " - " + PosDiff[0] + " = " + (vpose[0]-PosDiff[0]));
        //Debug.Log("MSG: " + vpose);
        //Debug.Log("Positions:\nInitial Pose: " + initial_pose + "\nMessage Pos: " + vpose + "\nDifference Pos: " + PosDiff + "\nFinal Pos: " + (vpose - PosDiff));
    }

    void onCollisionEnter(Collision collision){
        if (collision.collider.tag == "Touchable")
        {
            Debug.Log("La bola ha chocado");
        }
    }
}
