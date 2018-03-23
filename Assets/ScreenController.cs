using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour {

	public void NormalModeButtonClicked(){
		SceneManager.LoadScene("BasketBallGameVR"); // Başlangıç ekranında NormalMode seçeneğine basınca "Normal Mode" ekranını yüklemeye başlar.
	}
	public void CoderModeButtonClicked(){
		SceneManager.LoadScene("CoderBasketball"); // Başlangıç ekranında CoderMode seçeneğine basınca "Coder Mode" ekranını yüklemeye başlar
	}
	public void ExitModeButtonClicked(){
		Application.Quit (); //Başlangıç ekranında ExitGame seçeneğine basınca uygulama kapanır.
	}
}
