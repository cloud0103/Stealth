using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Vector3 offset;
    private Transform player;

    public float moveSpeed = 1;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
        offset = transform.position - player.position;
        offset = new Vector3(0, offset.y, offset.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 beginPos = player.position + offset;
        Vector3 endPos = player.position + offset.magnitude * Vector3.up;

        Vector3 pos1 = Vector3.Lerp(beginPos,endPos,0.25f);
        Vector3 pos2 = Vector3.Lerp(beginPos,endPos,0.5f);
        Vector3 pos3 = Vector3.Lerp(beginPos,endPos, 0.75f);

        Vector3[] posArray = new Vector3[] { beginPos, pos1, pos2, pos3, endPos };
        Vector3 targetPos = beginPos;
        for (int i = 0; i < 5; i++) {
            RaycastHit hitInfo;
            if (Physics.Raycast(posArray[i], player.position - posArray[i], out hitInfo))
            {
                if (hitInfo.collider.tag != Tags.PLAYER)
                {
                    continue;
                }
                else
                {
                    targetPos = posArray[i];
                    break;
                }
            }
            else {
                targetPos = posArray[i];
                break;
            }
        }
        transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime*moveSpeed);
        //transform.position = targetPos;
        transform.LookAt(player.position);
	}
}
