using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiChuyen : MonoBehaviour
{

    Rigidbody2D rp;
    private Animator _animation;
    private SpriteRenderer _spriteRenderer;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumForce = 6f;



    private enum MovemenState { idle,running , jumping,falling }



    // Start is called before the first frame update
    void Start()
    {
        rp = GetComponent<Rigidbody2D>();
        _animation = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxis("Horizontal");
        
        rp.velocity = new Vector2 (dirX * moveSpeed, rp.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rp.velocity = new Vector2(rp.velocity.x, jumForce);
        }


        UpdateAnimationUpdate();

    }


    private void UpdateAnimationUpdate()
    {

        MovemenState state;

        if (dirX != 0f)
        {
            state = MovemenState.running;
            if (dirX < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
        else
            state = MovemenState.idle;



        if(rp.velocity.y > .1f)
        {
            Debug.Log(rp.velocity.y);
            state = MovemenState.jumping;
        }
        else if(rp.velocity.y < -.1f)
        {
            state = MovemenState.falling;
        }
        _animation.SetInteger("state",(int)state);
    }
}
