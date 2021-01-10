
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControls : MonoBehaviour
{
void Update()
    {
		if ( Input.GetKeyDown( KeyCode.Return ) )
			SceneManager.LoadScene( "SampleScene" );
		if ( Input.GetKeyDown( KeyCode.Escape ) )
			SceneManager.LoadScene( "Title" );
	}
}
