using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

	public void Quit() //needs to be public for OnClick event
	{
#if UNITY_EDITOR //platform specific - if run in unity...
		UnityEditor.EditorApplication.isPlaying = false; //...close play mode...
#else //..otherwise, quit application.
		Application.Quit();
#endif
	}//Quit

}
