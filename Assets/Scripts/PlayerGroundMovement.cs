using UnityEngine;


public struct StateSettings {
    public Vector3 capsuleCenter;
    public float capsuleHeight;
    public float movementSpeed;
}

public class PlayerGroundMovement : MonoBehaviour
{
    private Rigidbody2D player_rb;
    private GameObject environment;
    private float dir_x;
    private Animator player_anim;
    public bool dontMove = false;
    private SpriteRenderer player_sr;
    private GameObject[] box_list;


    [SerializeField] private float x_speed;
    [SerializeField] private float jump_force;

    public StateSettings standing;
    public StateSettings crouching;

    private bool isGrounded;
    private bool isJumping = false;
    private bool isCrouching;
    private bool isPulling = false;

    // Start is called before the first frame update
    void Start()
    {
        environment = GameObject.FindWithTag("Environment");
        player_rb = GetComponent<Rigidbody2D>();
        dir_x = 0f;
        player_anim = GetComponent<Animator>();
        player_sr = GetComponent<SpriteRenderer>();
        box_list = GameObject.FindGameObjectsWithTag("Box");

    }

    // Update is called once per frame
    void Update()
    {
        dir_x = Input.GetAxis("Horizontal");
        player_anim.SetFloat("velocityx", dir_x*x_speed);



        if (Input.GetButtonDown("Jump") && !isJumping && environment.GetComponent<EnvironmentState>().GetState() == EnvState.Left)
        {
            isJumping = true;
            player_anim.SetBool("isJumping", true);
            player_rb.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);

        } else {
            player_anim.SetBool("isJumping", false);

        }

        if (Input.GetButton("Pull")){
            player_anim.SetBool("isPulling", true);
        }

         if (Input.GetButton("Pull") && !isJumping && environment.GetComponent<EnvironmentState>().GetState() == EnvState.Right)
        {
            isPulling = true;

            for (int i = 0; i < box_list.Length; i++) {
                if (Mathf.Abs(transform.position.y - box_list[i].transform.position.y) < 2f && Mathf.Abs(transform.position.x - box_list[i].transform.position.x) > 1f) {
                    box_list[i].GetComponent<BoxPullMovement>().BoxMoveTo(transform.position);

                } else {
                    
                    box_list[i].GetComponent<BoxPullMovement>().Halt();
                    player_anim.SetBool("isPulling", false);

                }                
            }       
        }
        else if(Input.GetButtonUp("Pull")) {
            isPulling = false;
            player_anim.SetBool("isPulling", false);
            for (int i = 0; i < box_list.Length; i++) {
                box_list[i].GetComponent<BoxPullMovement>().Halt();
            }       

        }

        if (Input.GetButton("Crouch") && environment.GetComponent<EnvironmentState>().GetState() == EnvState.Right)
        {
            isCrouching = true;

        }
        else
        {
            isCrouching = false;
        }
    }

    void FixedUpdate()
    {
        if (!dontMove)
        {
            if (!(isCrouching && dir_x < 0f)) {
                player_rb.velocity = new Vector2(dir_x * x_speed, player_rb.velocity.y);
            }

            if (Mathf.Abs(dir_x) > 0f)
            {
                // player_anim.SetBool("male_walking", true);
            }
            else
            {
                // player_anim.SetBool("male_walking", false);
                isJumping = false;
            }

            if (isCrouching)
            {
                // Add crouch behavior here
                player_anim.SetBool("Player_Crouching", true);
            }
            else
            {
                player_anim.SetBool("Player_Crouching", false);
            }
        }
        else
        {
            // player_anim.SetBool("male_walking", false);
            // player_anim.SetBool("Player_Crouching", false);
        }

        if (dir_x > 0)
        {
            player_sr.flipX = false;
            environment.GetComponent<EnvironmentState>().SetState(EnvState.Right);
        }
        else if (dir_x < 0)
        {
            player_sr.flipX = false;
            environment.GetComponent<EnvironmentState>().SetState(EnvState.Left);

        }
    }

    public void changeDontMove(bool val)
    {
        dontMove = val;
    }
}