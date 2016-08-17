using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	//Reference to our game objects
	public GameObject playButton;
	public GameObject Gyrocopter;
	public GameObject Goblin;
	public GameObject gameOverImage;
	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
	}

	GameManagerState GMState;
	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}
	
	//function to update the game manager state
	void updateGameManagerState()
	{
		switch (GMState)
		{
		case GameManagerState.Opening:

			//hide game over
			gameOverImage.SetActive(false);
			//Set play button visible(active)
			playButton.SetActive(true);
			break;
		case GameManagerState.Gameplay:
			//hide play button on game play state
			playButton.SetActive (false);

			//set the player visible(active) and init the player hit points
			Gyrocopter.GetComponent<GyrocopterController> ().Init ();
			Goblin.GetComponent<GoblinController>().Init();

			break;
		case GameManagerState.GameOver:

			//Set game over image active
			gameOverImage.SetActive(true);

			//change game manager to Opening state after 3 seconds
			Invoke("changeToOpeningState",3f);
	
			break;

		}
	}

	//function to set the game manager state
	public void setGameManagerState(GameManagerState state)
	{

		GMState = state;
		updateGameManagerState ();
	}

	//Our play button will call this function
	//when the user clicks the button
	public void startGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		updateGameManagerState ();

	}

	//function to change game manager state to opening state
	public void changeToOpeningState()
	{
		GMState = GameManagerState.Opening;
		updateGameManagerState ();

	}
}
