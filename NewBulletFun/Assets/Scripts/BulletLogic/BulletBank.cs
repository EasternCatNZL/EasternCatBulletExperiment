using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBank : MonoBehaviour {

    [HideInInspector]
    public Queue<RegularStraightBullet> regularBulletQueue = new Queue<RegularStraightBullet>();
    [HideInInspector]
    public Queue<SetupStraightBullet> setupStraightBulletQueue = new Queue<SetupStraightBullet>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //get bullet bullet from queue
    private RegularStraightBullet GetRegularStraightBullet()
    {
        return regularBulletQueue.Dequeue();
    }

    private SetupStraightBullet GetSetupStraightBullet()
    {
        return setupStraightBulletQueue.Dequeue();
    }

    //return bullet to queue
    private void ReturnRegularStraightBullet(RegularStraightBullet regularBullet)
    {
        regularBulletQueue.Enqueue(regularBullet);
    }

    private void ReturnSetupStraightBullet(SetupStraightBullet setupBullet)
    {
        setupStraightBulletQueue.Enqueue(setupBullet);
    }
}
