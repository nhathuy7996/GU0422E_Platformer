using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    Idle,
    Run,
    Jump,
    Skill
}

public enum SkillState {
    Skill1,
    Skill2,
    Skill3
}

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    [SerializeField] float _speed, _jumpForce;

    Rigidbody2D rigi;

    [SerializeField]
    bool _isGround = false;

    [SerializeField] PlayerState _playerState;
    SkillState _skillState;

    AnimationControllerBase _animController;

    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();

        _animController = this.GetComponentInChildren<AnimationControllerBase>();

        _animController._eventAction += (nameEvent) =>
        {
            if(nameEvent == "EndAnim") {
                Debug.LogError("Do sth on end anim");
            }

            if (nameEvent == "test1")
            {
                Debug.LogError("Do sth on end test1");
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        movement.y = rigi.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            rigi.AddForce(new(0, _jumpForce));
        } 
      
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, Vector2.down.magnitude);
        Debug.DrawRay(this.transform.position, Vector2.down, Color.red);
        if(hit.collider != null)
        {
            Debug.LogError(hit.collider.name);
        }

        UpdateState();
        UpdateAnimation();
    }


    void UpdateState() {
        if (!_isGround) {
            _playerState = PlayerState.Jump;
            return;
        }

        if (movement.x != 0)
        {
            _playerState = PlayerState.Run;
        }
        else
        {
            _playerState = PlayerState.Idle;
        }
    }

    void UpdateAnimation() {
        _animController.UpdateAnim(_playerState);
    }

    private void FixedUpdate()
    {
        rigi.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.CompareTag(CONSTANT.GroundTag))
            _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("Bat dau va cham");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.LogError("ket thuc va cham");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogError("Stay !!!!");
    }
}
