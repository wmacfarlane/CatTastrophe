using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Draw a button to start the game
		if (
			GUI.Button(

			new Rect(
			Screen.width / 8 ,
			(7 * Screen.height / 8) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Start!"
			)
			)
		{
			// On Click, load the first level.
			Application.LoadLevel("catastrophe1");
		}

		if (
			GUI.Button(

			new Rect(
			(3 * Screen.width / 8) - (buttonWidth / 2),
			(7 * Screen.height / 8) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Options"
			)
			)
		{
			// On Click, load the options menu.
			// Note: I haven't actually made the options menu yet, so it just loads the game.
			Application.LoadLevel("catastrophe1");
		}
	}
}