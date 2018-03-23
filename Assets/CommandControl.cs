using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CommandControl : MonoBehaviour {
	public Rigidbody ballPrefab;
	public float speed = 20.0F;
	private float startTime=0.0F;
	private float finishTime;
	public GameObject mainCamera;
	private float TimeOut=10.0F;
	private float previousCurrentTime=15.0F;
	private float CurrentTime;
	private int counter = 1;
	private int commandindex;
	public Dropdown dropdown;
	public Text UsageText;
	private List <string> Usageinformation = new List<string>();
	public InputField inputField;
	private float value;


	// Use this for initialization
	void Start(){
		Usageinformation.Add ("Usage:\nif (value > 0) {\n\tMoveForward(value);\n}\nelse {\n\tDontMove\n}");
		Usageinformation.Add ("Usage:\nif (value > 0) {\n\tMoveBack(value);\n}\nelse {\n\tDontMove\n}");
		Usageinformation.Add ("Usage:\nif (value > 0) {\n\tTurnLeft(value);\n}\nelse {\n\tDontTurn\n}");
		Usageinformation.Add ("Usage:\nif (value > 0) {\n\tTurnRight(value);\n}\nelse {\n\tDontTurn\n}"); //Usage information Listesini oluşturdum.
		Usageinformation.Add ("Usage:\n\nfor (i = 0; i < value; i++) \n{\n\tLookUp(i);\t\n}\n");
		Usageinformation.Add ("Usage:\n\nfor (i = 0; i < value; i++) \n{\n\tLookDown(i);\t\n}\n");
		Usageinformation.Add ("Usage:\nif (value > 0){\n\tShootPower (value);\n}\nelse{\n\tDontShoot\n}");


	}
	public void BackToMenu(){
		SceneManager.LoadScene ("StartMenu"); // Back to Menu butonuyla menüye dönülür.
	}
	public void Dropdown_IndexChanged(int index) // Komut Listesinde bir değişiklik olduğunda yeni komutun indexini alıyor.
	{

		Debug.Log (index);
		commandindex = index;
		UsageText.text = Usageinformation[commandindex];  //Ekran üzerindeki Usage kısmını bu index'teki komuta göre ayarlanır.

	}
	public void Text_Changed(string newText){
		value = float.Parse (newText);  // value değeri için ekrandaki ınput girme kısmındaki değeri alır
	}
	public void ApplyButtonClicked(){
		if (value > 0) {
			if (commandindex == 0) {
				this.transform.position += this.transform.forward * value; 
			}else if (commandindex == 1) {
				this.transform.position -= this.transform.forward * value; 
			}else if (commandindex == 2) {
				this.transform.Rotate (0,-value,0);           // index değerine göre bu if komutları gerekli işlemleri yapıyor.  
			}else if (commandindex == 3) {					  // Bu işlemler hareket etme, dönme ,yukarı bakma vs.
				this.transform.Rotate (0,value,0);
			}else if (commandindex == 4) {
				this.transform.Rotate (-value,0,0);
			}else if (commandindex == 5) {
				this.transform.Rotate (value,0,0);
			}else if (commandindex == 6) {
				var obj = (Rigidbody)Instantiate (ballPrefab, transform.position, transform.rotation); // Yeni basketbol topu oluşturur.
				obj.velocity = (mainCamera.transform.forward + mainCamera.transform.up / 1.2F) * speed * value/8; // Topa kuvvet uygula ve fırlat.
			}
		}
	}

}