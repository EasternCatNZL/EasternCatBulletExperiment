using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpray : MonoBehaviour {

    [Header("Timing Vars")]
    [Tooltip("Time Between Sprays")]
    public float timeBetweenSprays = 1.5f;

    [Header("Bullet Vars")]
    [Tooltip("Number of bullet waves")]
    public int numBulletWaves = 5;

    [Header("Bullet set up vars")]
    [Tooltip("Bullet base setup distance")]
    public float bulletBaseSetupDistance = 0.5f;
    [Tooltip("Bullet step distance increase value")]
    public float bulletStepDistanceIncrease = 0.5f;
    [Tooltip("Bullet setup move time")]
    public float bulletSetupTime = 0.5f;
    [Tooltip("Bullet active move start time")]
    public float bulletStartMoveTimeDelay = 0.2f;
    [Tooltip("Bullet angle change")]
    public float bulletAngleChange = 90.0f;
    [Tooltip("Pattern bullet set speed")]
    public float patternBulletSpeed = 2.0f;

    [Header("Angle Control")]
    [Tooltip("Facing angle")]
    public float facingAngle = 0.0f;

    [Header("Tags")]
    public string bulletBankTag = "Bullet Bank";

    //script refs
    private BulletBank bank;

    //control vars
    private float timeLastSprayFired = 0.0f; //the time last spray began

    // Use this for initialization
    void Start () {
        bank = GameObject.FindGameObjectWithTag(bulletBankTag).GetComponent<BulletBank>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeLastSprayFired + timeBetweenSprays)
        {
            StartCoroutine(BulletSprayRoutine());
        }
    }

    //bullet firing coroutine
    private IEnumerator BulletSprayRoutine()
    {

        yield return new WaitForSecondsRealtime(timeBetweenSprays);
    }
}
