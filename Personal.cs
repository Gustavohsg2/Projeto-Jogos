using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personal:MonoBehaviour {
	float Vx;
	float Vy;
	float DirecaoHorizontal;
	float VelocidadeAndar;
	Rigidbody2D CorpoRigido;
	float VelocidadePulo;
	BoxCollider2D Colisor;

	void Start (){
		Vx = 0;
		Vy = 0;
		VelocidadeAndar = 5;
		DirecaoHorizontal = 0;
		VelocidadePulo = 9;
		CorpoRigido = GetComponent <Rigidbody2D> ();
		Colisor = GetComponent<BoxCollider2D>();
		CorpoRigido.freezeRotation = true;
	}

	void Update (){
		Andar();
		PuloSimples();
	}

	void Andar(){
		DirecaoHorizontal = Input.GetAxis("Horizontal");
		Vx = VelocidadeAndar*DirecaoHorizontal;
		Vy = CorpoRigido.velocity.y;
		Vector2 velocidadeX = new Vector2(Vx,Vy);
		CorpoRigido.velocity = velocidadeX;
	}
	void PuloSimples(){
		bool apertouBotao = Input.GetButtonDown("Jump");
		bool estaTocandoAlgo = Colisor.IsTouchingLayers();
		if(apertouBotao == true && estaTocandoAlgo == true){
			Vx = CorpoRigido.velocity.x;
			Vy = VelocidadePulo;
			Vector2 velocidadePulo = new Vector2(Vx, Vy);
			CorpoRigido.velocity = velocidadePulo;

		}
	}
	void OnCollisionEnter2D(Collision2D objetoTocado){
		string tagTocada = objetoTocado.gameObject.tag; 

		if (tagTocada == "Energetico1" && VelocidadeAndar < 10) {
			VelocidadeAndar = VelocidadeAndar + 1;
			VelocidadePulo = VelocidadePulo + 5;
			Destroy (objetoTocado.gameObject);		
			print ("VELOCIDADE: " + VelocidadeAndar);
		}
		if (tagTocada == "Coca-Cola" && VelocidadeAndar >= 2) {
			Destroy (objetoTocado.gameObject);
			print ("VELOCIDADE: " + VelocidadeAndar);
			VelocidadeAndar = VelocidadeAndar - 1;
			VelocidadePulo = VelocidadePulo - 3;

		}
		if (tagTocada == "bomba") {
			//se o personagem tocar na bomba, o personagem(gamme object) é destruído.
			Destroy (gameObject);
		}	
	}
}
