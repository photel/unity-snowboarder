using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
      if (other.gameObject.tag == "Ground") {
        trailEffect.Play();
      }
    }

    private void OnCollisionExit2D(Collision2D other) {
      if (other.gameObject.tag == "Ground") {
        trailEffect.Stop();
      }
    }
}
