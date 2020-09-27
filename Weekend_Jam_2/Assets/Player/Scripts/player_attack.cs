using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour {
  private player_stats ps;
  private GameObject hitbox;
  private Rigidbody2D rb;
  private Animator animator;

  private float slash;
  private float slashDurationCounter;

  private float dash;
  private float dashDuration;

  private float direction;

  private float fire;
  private GameObject firePoint;
  public GameObject firePrefab;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
    hitbox = GameObject.Find("hit_zone");
    rb = gameObject.GetComponent<Rigidbody2D>();
    animator = gameObject.GetComponent<Animator>();

    slash = 0;
    slashDurationCounter = 0;

    dash = 0;
    dashDuration = 0;

    direction = -1;

    firePoint = GameObject.Find("firePoint");
  }

  // Update is called once per frame
  void Update() {
    /* Dash attak */
    if (Input.GetAxis("dash") > 0 && dash <= 0) {
      if (Input.GetAxis("horizontal") > 0)
        direction = 1;
      else
        direction = -1;

      rb.AddForce(new Vector2(ps.dashSpeed * direction, 0));
      ps.onDash = true;
      dashDuration = ps.dashDuration;
      dash = ps.dashCd;
    }

    if (dash > 0)
      dash -= Time.deltaTime;

    if (dashDuration > 0)
      dashDuration -= Time.deltaTime;
    else
      ps.onDash = false;
    /***/

    /* Slash attack */
    if (slash > 0)
      slash -= Time.deltaTime;

    if (Input.GetAxis("attack") > 0 && slash <= 0) {
      slash = ps.slashCd;
      slashDurationCounter = ps.slashDuration;

      animator.SetBool("slash", true); // Animation
      hitbox.SetActive(true);
    } else {
      if (slashDurationCounter <= 0) {
        animator.SetBool("slash", false); // Animation
        hitbox.SetActive(false);
      } else {
        slashDurationCounter -= Time.deltaTime;
      }
    }
    /***/

    /* fire attack */
    if (fire > 0) {
      fire -= Time.deltaTime;
    }

    if (Input.GetAxis("fire") > 0 && fire <= 0) {
      fire = ps.fireCd;
      Instantiate(firePrefab, firePoint.transform.position, Quaternion.identity);
    }
    /***/
  }
}
