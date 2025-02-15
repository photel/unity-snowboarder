using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float torqueAmount = 0.1f;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 25f;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
      rb2d = GetComponent<Rigidbody2D>();
      surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update() {
      if (canMove) {
        RotatePlayer();
        accelerate();
      };
    }

    public void DisableControls() {
      canMove = false;
      surfaceEffector2D.speed = slowSpeed;
    }

    private void RotatePlayer() {
      if (Input.GetKey(KeyCode.LeftArrow)) {
        rb2d.AddTorque(torqueAmount);
      } else if (Input.GetKey(KeyCode.RightArrow)) {
        rb2d.AddTorque(-torqueAmount);
      }
    }

    private void accelerate() {
      if (Input.GetKey(KeyCode.UpArrow)) {
        surfaceEffector2D.speed = boostSpeed;
      } else if (Input.GetKey(KeyCode.DownArrow)) {
        surfaceEffector2D.speed = slowSpeed;
      } else {
        surfaceEffector2D.speed = baseSpeed;
      }
    }
}
