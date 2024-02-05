using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
