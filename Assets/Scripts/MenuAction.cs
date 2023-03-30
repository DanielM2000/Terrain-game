using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuAction : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (this.name == "PlayBtn")
        {
            // Application.LoadLevel("TheGame"); OLDER VERSIONS OF UNITY USE THIS
            SceneManager.LoadScene("TheGame");
        }
    }
}
