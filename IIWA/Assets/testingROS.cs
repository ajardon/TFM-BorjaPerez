using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Robotics.ROSTCPConnector;
using PoseMsg = RosMessageTypes.Geometry.PoseMsg;
using PoseStampedMsg = RosMessageTypes.Geometry.PoseStampedMsg;

public class testingROS : MonoBehaviour
{
    public ROSConnection ros;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();

        Debug.Log("REGISTRAMOS TODO");
        //ros.RegisterPublisher<CollMsg>("/iiwa/id_1/collision_point");
        ros.Subscribe<PoseStampedMsg>("/iiwa/id_1/ee_pose", aux);
    }

    void aux(PoseStampedMsg pose){
        Debug.Log("POSE RECIBIDA:\n" + pose);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
