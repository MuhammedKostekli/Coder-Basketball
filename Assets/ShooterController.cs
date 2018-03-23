using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShooterController : MonoBehaviour {
	public Rigidbody ballPrefab;  // Basketball Top Objesi
	public float speed = 20.0F;  
	private float startTime=0.0F; 
	private float finishTime;	
	public GameObject mainCamera; // Oyunun temel kamerası
	private float TimeOut;  // 15 saniyeyi hesaplamak için değişken
	private float previousCurrentTime=15.0F;  // bir önceki frame için zaman değişkeni
	private float CurrentTime;
	private int counter = 1;
	private bool timeStarted=false; // Ekrana temas edildiğinde, zaman ölçümünün başlamasını kontrol  
	private int touchNumber; //Ekrana temas eden parmak sayısı için değişken



	public void BackToMenu(){  
		SceneManager.LoadScene ("StartMenu");	// Menu Butonuna basıldığında "StartMenu" ekranını yükle.
	}

	// Update is called once per frame
	void Update () {
		TimeOut = previousCurrentTime - Time.time;    
		if (TimeOut < 0) {							//Her 15 saniyede bir bu if komutu çalışıyor.
			int x = Random.Range (230,295);
			int z =	Random.Range (315,350);
			this.transform.position = new Vector3 (x,71.3F,z); //Hesaplanan random x,z değerlerine karakteri taşı.
			counter++;
			previousCurrentTime = counter * 15.0F; 
		}

		
		if (Input.GetButtonDown("Fire1") && Input.touchCount == 1) {  // Ekrana basılmaya başladığında ve ekrandaki temas eden parmak sayısı 1 ise
		
			startTime = Time.time;						// Ekrana basılan anı hesaplayıp değişkene atadım.
			timeStarted = true;


		}
		/*if (Time.time - startTime > 3.0F && Input.GetButton("Fire1")) {
			
			transform.position = transform.position + new Vector3(mainCamera.transform.forward.x,0,mainCamera.transform.forward.z) * 25.0F * Time.deltaTime;
		}*/
		touchNumber = Input.touchCount;  //Ekrandaki temas sayısını hesapla ve değişkene ata
		if (timeStarted == true && touchNumber<2 && Input.GetButtonUp("Fire1") && Time.time - startTime <= 5.0F ) { //ekrandaki temas kaybolduğu zaman bu if komutu çalışır.
			finishTime = Time.time - startTime; // Ekrana temas edilen süreyi hesapla
			var obj = (Rigidbody)Instantiate (ballPrefab, transform.position, transform.rotation); // Yeni top objesi oluştur
			obj.velocity = (mainCamera.transform.forward + mainCamera.transform.up / 1.2F) * speed * finishTime * 2; // Bu topa temas edilen süre kadar top objesine kuvvet uygula.
			timeStarted = false;
				
		}

	}
}