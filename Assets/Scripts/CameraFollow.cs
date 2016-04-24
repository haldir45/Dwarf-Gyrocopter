using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject gyrocopter;

    // Use this for initialization
    void Start () {
        //find the player object
        gyrocopter = GameObject.FindWithTag("Gyrocopter");
    }

    // Update is called once per frame
    void Update () {
        //follow the player
        if (gyrocopter != null)
        {
            this.transform.position = new Vector3(gyrocopter.transform.position.x, gyrocopter.transform.position.y, this.transform.position.z);
        }
	}
}
