using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	public float BulletSpeed = 100.0f;

	private Transform bulletTrans = null;

	// Use this for initialization
	private void Awake()
	{
	}
	void Start () {

		// 제일 상단에 표시한다.
		// bulletTrans = this.gameObject.transform  같은 결과.
		bulletTrans = this.GetComponent<Transform>();

		// 아무것도 안적으면 최상위 하나.
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveAmount = BulletSpeed * Vector3.up * Time.deltaTime;
		bulletTrans.Translate(moveAmount, Space.World);

		if(bulletTrans.position.y >= 56)
		{
			// 이러면 멈춘다. this.gameObject.SetActive(false);
			Destroy(this.gameObject); 
		}

	}
}
