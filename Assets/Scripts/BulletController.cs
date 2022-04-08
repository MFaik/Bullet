using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] LineRenderer DottedLine;    
    [SerializeField] Transform MouseTarget;

    [SerializeField] float Speed = 5;

    [SerializeField] GameObject DestroyParticle;

    [SerializeField] GameObject Restart;

    float epoch = 0;

    void Update() {
        epoch += Time.deltaTime;
        epoch = epoch - (int)epoch;

        DottedLine.SetPosition(0,transform.position + (MouseTarget.position - transform.position).normalized * epoch);
        DottedLine.SetPosition(1,MouseTarget.position);

        transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(MouseTarget.position.y - transform.position.y,MouseTarget.position.x - transform.position.x)*Mathf.Rad2Deg);

        transform.position += (MouseTarget.position - transform.position).normalized * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Target")){
            Restart.SetActive(true);
            ScoreCounter.StopGame();
            Instantiate(DestroyParticle,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(DottedLine.gameObject);
            Destroy(gameObject);
        }    
    }
}
