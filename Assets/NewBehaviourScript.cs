using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	//指のIDを設定
	private int rightFingerId = 0;
	private int leftFingerID = 0;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}


		//touchCountにはタッチしている指の本数が入っている。指の本数分処理を繰り返してマルチタッチをチェックしている。

		for (int i = 0; i < Input.touchCount; i++){

			//タッチした指のIDが取得できる。このIDは指ごとにかぶることのない一意のID
			int id = Input.touches [i].fingerId;

			//タッチ状態を取得できる
			TouchPhase phase = Input.touches [i].phase;

			//タッチした2次元座標
			Vector2 pos = Input.touches [i].position;

			//タッチ開始時の場合
			if (phase == TouchPhase.Began) {
				//
				if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag"){
					//右半分をタッチしたIDを記録する
					rightFingerId = id;
					SetAngle (this.flickAngle);

					//現在タッチした座標が画面の半分座標おり小さい場合
				} else if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag"){
						//左半分をタッチした指のIDを記録しておく
						leftFingerID = id;
						SetAngle(this.flickAngle);
					}

					//タッチ終了時の場合
				} else if (phase == TouchPhase.Ended) {
						//離した指のIDが右半分をタッチした指IDの場合
					if (id == rightFingerId && tag == "RightFripperTag"){
							SetAngle (this.defaultAngle);

							//離した指IDが左半分をタッチしたものの場合
						}else if (id == leftFingerID && tag == "LeftFripperTag") {
							SetAngle(this.defaultAngle);
						}
					}
				}


		}


	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}



