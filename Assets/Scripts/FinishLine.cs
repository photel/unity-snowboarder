using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float winReloadDelay = 3f;
    [SerializeField] ParticleSystem winEffect;
    AudioSource finSfx;

    // Start is called before the first frame update
    void Start() {
        finSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "Player") {
        winEffect.Play();
        finSfx.Play();

        Invoke("ReloadScene", winReloadDelay);
      }
    }

    private void ReloadScene() {
      SceneManager.LoadScene("Level1");
    }
}
