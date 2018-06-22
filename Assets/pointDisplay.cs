using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pointDisplay : MonoBehaviour {
	// Materialを入れる
	Material myMaterial;

	//点数を表示するテキスト
	private GameObject point;

	//点数(変数）の宣言：スコアをいれておく変数が必要
	float points = 0f;


	// Use this for initialization
	void Start () {
		
		//シーン中のPointsオブジェクトを取得（Pointを表示するための）
		this.point = GameObject.Find("PointDisplay");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//衝突時に呼ばれる関数(決まった関数名）other：他のオブジェクト。あたったオブジェクトのタグの情報が取得できる。
	void OnCollisionEnter(Collision other){
		//ボールがあたったたぐで判定
		if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag") {
			this.points += 10;
			Debug.Log (this.points);
			this.point.GetComponent<Text> ().text = "score" + points.ToString ();
			//textはストリング型、intを文字列に変更する
		
		} else if (other.gameObject.tag == "LargeStarTag") {
			this.points += 20;
			Debug.Log (this.points);
			this.point.GetComponent<Text> ().text = "score" + points.ToString ();

		}else if (other.gameObject.tag == "LargeCloudTag"){
			this.points += 30;
			Debug.Log (this.points);
			this.point.GetComponent<Text> ().text = "score" + points.ToString ();
		}
	}
}
