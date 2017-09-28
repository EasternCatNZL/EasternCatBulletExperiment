using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SetupStraightBullet : MonoBehaviour {

    public float travelSpeed = 2.0f;

    //set up vars
    public Vector3 setupDestination = new Vector3(0, 0, 0);
    public float setupDestinationDistance = 0.0f;
    public float setupTime = 0.0f;
    public float startDelay = 0.0f;
    public float angleChange = 0.0f;

    //control vars
    private float startTime = 0.0f;
    public bool isStarting = false;
    private bool isReady = false;

    private Rigidbody myRigid;

    // Use this for initialization
    void Start () {
        myRigid = GetComponent<Rigidbody>();
        startTime = Time.time;
        //SetUp();
    }
	
	// Update is called once per frame
	void Update () {
		if (isStarting)
        {
            SetUp();
        }
	}

    //sets up vars for bullet behaviour
    public void SetupVars(float dist , float setTime, float delay, float angle, float speed)
    {
        setupDestinationDistance = dist;
        setupTime = setTime;
        startDelay = delay;
        angleChange = angle;
        travelSpeed = speed;
        isStarting = true;
    }

    //func called when setup ready
    private void SetUp()
    {
        isStarting = false;
        setupDestination = transform.position + (transform.forward * setupDestinationDistance);
        transform.DOMove(setupDestination, setupTime, false);
        //transform.DOMove(new Vector3(2, 1, 3), 2, false);
        StartCoroutine(BeginMove());
    }

    private IEnumerator BeginMove()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        transform.Rotate(transform.up, angleChange);
        myRigid.velocity = transform.forward * travelSpeed;
    }
}
