using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static void ReloadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
