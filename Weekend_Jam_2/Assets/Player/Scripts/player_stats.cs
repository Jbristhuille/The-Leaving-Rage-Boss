using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_stats : MonoBehaviour {
  public bool isGrounded;

  public float speed;
  public float jumpSpeed;

  public int damage;
  public int pv;

  public float slashCd;
  public float slashDuration;

  public bool onDash;
  public float dashCd;
  public float dashSpeed;
  public float dashDuration;

  public float fireCd;
  public float fireSpeed;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    if (pv <= 0) { // Player death
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
