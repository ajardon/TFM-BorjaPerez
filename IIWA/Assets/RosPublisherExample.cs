using UnityEngine;
using RosMessageTypes.UnityRoboticsDemo;

using RosMessageTypes.Geometry;
using ROSGeometryMsgs = RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector;
using CollMsg = RosMessageTypes.Roboasset.CollisionPointMsg;

/// <summary>
///
/// </summary>
public class RosPublisherExample : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/iiwa/id_1/collision_point";

    // The game object
    public GameObject sphere;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        //ros = ROSConnection.GetOrCreateInstance();
        //RosTopicState pub = ros.RegisterPublisher<CollMsg>(topicName);
        //Debug.LogWarning(pub);
        //ros.RegisterPublisher<CollMsg>(topicName);
        //ros.Subscribe<PoseMsg>("/iiwa/id_1/ee_pose", aux);
        // Debug.Log("Linea dibujada");
    }

    void aux(PoseMsg pose_msg)
    {
        Debug.Log("RECIBIENDO " + pose_msg);
    }

    private void Update()
    {
        Color color_dist = new Color(1.0f, 0.0f, 0.0f); // red
        Debug.DrawLine(this.transform.position + new Vector3(0f, 0.15f, 0f), sphere.transform.position, color_dist);
        // PointMsg contactPoint = new PointMsg(
        //     this.transform.position.x,
        //     this.transform.position.y,
        //     this.transform.position.z
        // );
        // bool onCollision = false;
        // //HACER TRANSFORMACIÓN POS-UNITY A POS-IIWA
        // CollMsg collPoint = new CollMsg(
        //     onCollision,
        //     contactPoint
        // );

        // ros.Publish(topicName, collPoint);
    }
}
