using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetect : MonoBehaviour
{
    [SerializeField] float crashReloadDelay = 1.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSfx;
    bool hasCrashed = false;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "Ground" && !hasCrashed) {
        FindAnyObjectByType<PlayerController>().DisableControls();
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSfx);
        hasCrashed = true;
        
        Invoke("ReloadScene", crashReloadDelay);
      }
    }

    private void ReloadScene() {
      SceneManager.LoadScene("Level1");
    }
}
