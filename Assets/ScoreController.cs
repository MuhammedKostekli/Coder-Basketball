using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
		
	public GameObject ScoreText;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Basketball(Clone)") {
			ScoreText.SetActive (true);
		} 
	}
	void OnCollisionExit(Collision col){
		
		ScoreText.SetActive (false);
		
	}


}
