using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamSpawner : MonoBehaviour
{
    [SerializeField] Adam AdamPrefab;
    [SerializeField] int MaxAdam = 15;
    int _currentAdamCount = 0;

    Camera _mainCamera;

    void Start() {
        _mainCamera = Camera.main;
    }

    public void StartGame() {
        InvokeRepeating(nameof(SpawnAdam),2,3);
    }

    void SpawnAdam() => SpawnAdam(false);

    public void SpawnAdam(bool destroyed) {
        if(!destroyed){
            if(_currentAdamCount >= MaxAdam)
                return;
            _currentAdamCount++;
        }
        float startX = (Random.Range(0,2)*2-1) * (_mainCamera.orthographicSize*_mainCamera.aspect+1);
        float startY = Random.Range(-1,2) * (_mainCamera.orthographicSize+1);
        Adam insAdam = Instantiate(AdamPrefab,new Vector2(startX,startY),Quaternion.identity);
        insAdam.Init(this,new Vector2(-startX,-startY));
    }    

    void Update() {
        
    }
}
