using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adam : MonoBehaviour
{
    [SerializeField] float MinSpeed = 3, MaxSpeed = 10;
    Rigidbody2D _rigidBody;
    Vector2 _direction;
    float _waitTime = 0;

    [SerializeField] List<Sprite> Sprites;

    AdamSpawner _adamSpawner;

    
    void Awake() {
        _rigidBody = GetComponent<Rigidbody2D>();
        GetComponentInChildren<SpriteRenderer>().sprite = Sprites[Random.Range(0,Sprites.Count)];    
    }

    public void Init(AdamSpawner adamSpawner, Vector2 startDirection) {
        _adamSpawner = adamSpawner;
        _direction = startDirection.normalized*MaxSpeed;
        _waitTime = 2f;
    }

    void Update() {
        if(_waitTime <= 0){
            float xSpeed = (Random.Range(0,2)*2-1) * Random.Range(MinSpeed,MaxSpeed);
            float ySpeed = (Random.Range(0,2)*2-1) * Random.Range(MinSpeed,MaxSpeed);
            
            _direction = new Vector2(xSpeed,ySpeed);
            _waitTime = Random.Range(2f,3f);
        } else {
            _waitTime -= Time.deltaTime;
        }

        _rigidBody.velocity = _direction;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("AdamDestroyer")){
            Destroy(gameObject);    
            _adamSpawner.SpawnAdam(true);
        }
    }
}
