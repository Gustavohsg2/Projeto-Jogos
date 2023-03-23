using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D objetoTocado){
		string tagTocada = objetoTocado.gameObject.tag; 

		if (tagTocada == "acertar1") {
			Destroy (objetoTocado.gameObject);
			Destroy (gameObject);
		}	
	}
}

