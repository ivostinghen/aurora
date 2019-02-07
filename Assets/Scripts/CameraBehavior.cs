using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    Transform target;
    public float speed;
    Vector3 pos;
    public Vector3 offSet;

    private void Start()
    {
        target = GameObject.Find("Character").transform;
    }

   
    void LateUpdate () {
        pos = target.position;
        pos += offSet;
        transform.position = Vector3.Lerp(transform.position,pos, Time.deltaTime * speed);
	}   
}
