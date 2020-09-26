using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour {
  private player_stats ps;
  private GameObject hitbox;
  private float slash;
  private float slashDurationCounter;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
    hitbox = GameObject.Find("hit_zone");
    slash = 0;
    slashDurationCounter = 0;
  }

  // Update is called once per frame
  void Update() {
    Debug.Log(slash);

    if (slash > 0)
      slash -= Time.deltaTime;

    if (Input.GetAxis("attack") > 0 && slash <= 0) {
      slash = ps.slashCd;
      slashDurationCounter = ps.slashDuration;

      hitbox.SetActive(true);
    } else {
      if (slashDurationCounter <= 0) {
        hitbox.SetActive(false);
      } else {
        slashDurationCounter -= Time.deltaTime;
      }
    }
  }
}
