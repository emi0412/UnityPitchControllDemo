using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControll : MonoBehaviour {
    private Rigidbody myRigid;
    [SerializeField]
    private float torquePower;
    [SerializeField]
    private AudioSource idleSound;

	// Use this for initialization
	void Start () {
        myRigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            idleSound.time = 0;
            idleSound.Play();
            print("Sound Play");
        }

        // マウスの左ボタンが押されている間
		if ( Input.GetMouseButton(0) )
        {
            // this.gameobjectを回転させ続ける
            myRigid.AddTorque(Vector3.right * torquePower, ForceMode.Force);
            // idleSoundの再生位置が5秒を超えていた場合
            // 再生位置を1秒に戻す
            if ( idleSound.time > 5.0f )
            {
                idleSound.time = 1.0f;
            }
            print("Now Playing:" + idleSound.time.ToString());
        }
        else if (myRigid.angularVelocity.magnitude < 0.1f && idleSound.isPlaying)
        {
            // 回転力量が一定値を下回り、idleSoundを再生していた場合
            // idleSoundをStopする
            idleSound.Stop();
            print("Sound Stop");
        }

        // pitchをcubeの回転力量に応じて変化させる
        idleSound.pitch = 1 + myRigid.angularVelocity.magnitude / 5;


	}
}
