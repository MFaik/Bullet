using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    Camera _mainCamera;
    
    void Start() {
        _mainCamera = Camera.main;
    }

    void Update() {
        transform.position = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
