using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

  private bool player_near_switch;

  private GameObject environment;

  private GameObject[] triggered_platforms;

  [SerializeField] private bool conditional_switch;

  [SerializeField] private EnvState active_state;


  private bool isPressed = false;
  public Sprite PressedSprite;
  public Sprite NotPressedSprite;

  private BoxCollider2D switch_bc;
  private SpriteRenderer switch_sr;

  private Animator anim;

  private AudioSource click_sound;

  [SerializeField] private bool contControl;

  void Start()
  {
    player_near_switch = false;
    environment = GameObject.FindWithTag("Environment");
    triggered_platforms = GameObject.FindGameObjectsWithTag("TriggeredPlatform");
    switch_bc = GetComponent<BoxCollider2D>();
    switch_sr = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    click_sound = GetComponent<AudioSource>();
  }

  void Update()
  {
    if (player_near_switch)
    {
      isPressed = true;
    }
    else
    {
      isPressed = false;
    }

    if (conditional_switch)
    {
      ShowSwitchOnCondition();
    }

    if (isPressed)
    {
      switch_sr.sprite = PressedSprite;
      for (int i = 0; i < triggered_platforms.Length; i++)
        triggered_platforms[i].GetComponent<PlatformMovement>().contControl = contControl;
    }
    else
    {
      switch_sr.sprite = NotPressedSprite;
      for (int i = 0; i < triggered_platforms.Length; i++)
        triggered_platforms[i].GetComponent<PlatformMovement>().contControl = false;
    }
  }

  private void ShowSwitchOnCondition()
  {
    EnvState currentState = environment.GetComponent<EnvironmentState>().GetState();
    if (active_state == currentState)
    {
      switch_bc.enabled = true;
      switch_sr.enabled = true;
    }
    else
    {
      switch_bc.enabled = false;
      switch_sr.enabled = false;
    }
  }

  private void FlipSwitch()
  {
    click_sound.Play();
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    // if (collider.CompareTag("Player")) {
    player_near_switch = true;
    FlipSwitch();
    if (!contControl)
      MoveAllTriggeredPlatforms();
    // }
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    // if (collider.CompareTag("Player")) {
    player_near_switch = false;
    FlipSwitch();
    if (!contControl)
      MoveAllTriggeredPlatforms();
    // }
  }

  private void MoveAllTriggeredPlatforms()
  {
    if (triggered_platforms.Length > 0)
    {
      for (int i = 0; i < triggered_platforms.Length; i++)
      {
        triggered_platforms[i].GetComponent<PlatformTriggeredMovement>().PlatformMoveToNext();
      }
    }
  }
}
