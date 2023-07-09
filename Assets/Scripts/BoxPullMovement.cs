using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPullMovement : MonoBehaviour
{

  [SerializeField] private float box_x_speed;
  private GameObject environment;
  private GameObject player;



  private Animator boxAnimation;
  public Sprite normal;
  public Sprite isPulled;
  private SpriteRenderer sr_render;
  private bool isNormal = true;

  private void Start() {
    environment = GameObject.FindWithTag("Environment");
    player = GameObject.FindWithTag("Player");
    sr_render = GetComponent<SpriteRenderer>();
  }

  private void Update() {

      if (isNormal) {
        sr_render.sprite = normal;
      } else {
        sr_render.sprite = isPulled;
      }
  }

  public void BoxMoveTo(Vector2 destination) {
    if (environment.GetComponent<EnvironmentState>().GetState() == EnvState.Right) {
      transform.position = Vector2.MoveTowards(transform.position, new Vector2(destination.x, destination.y), box_x_speed * Time.deltaTime);
      isNormal = false;
    }
  }



  public void Halt() {
    // prevent more motion
    transform.position = transform.position;
    isNormal = true;
  }
}
