using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* this script is for the melee enemy
 * enemy game object needs two game objects attached to it for wall and edge detection
 * there has to be a layer for the ground or whatever the characters are standing on
 * there has to be a layer for the player character
*/
public class OpossumEnemyMovement : MonoBehaviour
{
    // sprite handling
    [Header("For Flipping Sprite")]
    [SerializeField] private bool _moveRight = true;
    [SerializeField] private float _localScaleX;
    [SerializeField] private float _localScaleY;
    [SerializeField] private float _localScaleZ;

    // wall detection
    [Header("Wall Checks")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckRadius;
    [SerializeField] private LayerMask _whatIsWall;
    [SerializeField] private bool _hittingWall;

    // edge detection
    [Header("Edge Checks")]
    [SerializeField] private Transform _edgeCheck;
    [SerializeField] private bool _notAtEdge;

    // components for enemy and what is player
    [HideInInspector] public Rigidbody2D _enemyRb;
    [HideInInspector] public Animator _anim;
    [HideInInspector] public Transform _player;

    // movement
    [Header("Enemy Move")]
    public float _moveSpeed;
    public float _range;
    public float _stopDistance;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // checking if _hittingWall, _notAtEdge, _hitPlayer are true or not
        _hittingWall = Physics2D.OverlapCircle(_wallCheck.position, _wallCheckRadius, _whatIsWall);
        _notAtEdge = Physics2D.OverlapCircle(_edgeCheck.position, _wallCheckRadius, _whatIsWall);

        // there has to be a player for the enemy to move at all
        if (_player != null)
        {
            if (_hittingWall || !_notAtEdge)
            {
                _moveRight = !_moveRight;
            }
            

            if (_moveRight)
            {
                transform.localScale = new Vector3(_localScaleX, _localScaleY, _localScaleZ);
                _enemyRb.velocity = new Vector2(_moveSpeed, _enemyRb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(-_localScaleX, _localScaleY, _localScaleZ);
                _enemyRb.velocity = new Vector2(-_moveSpeed, _enemyRb.velocity.y);
            }

            // enemy stops moving if enemy gets too close to player based on _stopDistance
            if (Mathf.Abs(transform.position.x - _player.position.x) < _stopDistance && Vector2.Distance(transform.position, _player.position) <= _range)
            {
                _enemyRb.velocity = new Vector2(0, 0);

                // enemy to the right of player
                if (transform.position.x > _player.position.x)
                {
                    transform.localScale = new Vector3(-_localScaleX, _localScaleY, _localScaleZ);
                    _moveRight = false;
                }
                // enemy to the left of player
                else if (transform.position.x < _player.position.x)
                {
                    transform.localScale = new Vector3(_localScaleX, _localScaleY, _localScaleZ);
                    _moveRight = true;
                }
            }
        }
    }

    // Upon collision with Player, this GameObject will destroy itself
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

