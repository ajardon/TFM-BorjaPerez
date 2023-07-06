using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;

/// <summary>
///
/// </summary>
public class sendCollisionPoint : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/coll_point";

    // The game object
    public GameObject cube;


    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PosRotMsg>(topicName);
    }

    private void Update()
    {
	
    }
    
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            PosRotMsg collisionPoint = new PosRotMsg((float)contact.point.x, (float)contact.point.y, (float)contact.point.z, (float)0.0, (float)0.0, (float)0.0, (float)0.0);
            ros.Publish(topicName, collisionPoint);
        }
    }
}
