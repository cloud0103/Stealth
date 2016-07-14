using UnityEngine;
using System.Collections;

public class FollowOutDoor : MonoBehaviour {

    public Transform leftOutDoor;
    public Transform rightOutDoor;
    public Transform leftInterDoor;
    public Transform rightInterDoor;
    public float speed = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //电梯内门跟随外门打开/关闭
        float leftDoorX = Mathf.Lerp(leftInterDoor.position.x, leftOutDoor.position.x,Time.deltaTime*speed);
        float rightDoorX = Mathf.Lerp(rightInterDoor.position.x, rightOutDoor.position.x,Time.deltaTime* speed);
        leftInterDoor.position = new Vector3(leftDoorX, leftInterDoor.position.y, leftInterDoor.position.z);
        rightInterDoor.position = new Vector3(rightDoorX, rightInterDoor.position.y, rightInterDoor.position.z);
	}
}
