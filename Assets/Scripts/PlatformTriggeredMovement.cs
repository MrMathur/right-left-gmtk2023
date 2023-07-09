using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggeredMovement : MonoBehaviour
{
  [SerializeField] private GameObject[] waypoints;
  private GameObject current_wapoint;
  private int current_waypoint_index;
  [SerializeField] private float y_speed;
  private AudioSource move_sound;
  // Start is called before the first frame update
  void Start()
  {
    current_waypoint_index = 0;
    current_wapoint = waypoints[current_waypoint_index];
    move_sound = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Vector2.Distance(transform.position, current_wapoint.transform.position) > 0.1f)
    {
      transform.position = Vector2.MoveTowards(transform.position, current_wapoint.transform.position, y_speed * Time.deltaTime);
    }
  }

  public void PlatformMoveToNext()
  {
    move_sound.Play();
    current_waypoint_index = (current_waypoint_index + 1) % waypoints.Length;
    current_wapoint = waypoints[current_waypoint_index];
  }
}
