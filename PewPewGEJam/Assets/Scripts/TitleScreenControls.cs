
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControls : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Return ) )
            SceneManager.LoadScene( "SampleScene" );
        if ( Input.GetKeyDown( KeyCode.Escape ) )
            Application.Quit();
    }
}
