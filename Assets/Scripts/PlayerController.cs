using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D),typeof(TouchingDirections),typeof(Damageable))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;
    private float averageXSpeed;
    public float jumpImpulse = 10.0f;

    static readonly int CACHE_SIZE = 3;
    float[] speedCache = new float[CACHE_SIZE];
    int currentCacheIndex = 0;

    public float CurrentMoveSpeed 
    { 
        get 
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {
                        if (IsRunning)
                        {
                            return runSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }
                    else
                    {
                        return averageXSpeed;
                    }
                }
                else
                {
                    //idle speed is 0.
                    return 0;
                }
            }
            else
            {
                //Movement locked
                return 0;
            }
        } 
    }
    Vector2 moveInput;

    Rigidbody2D rb;
    Animator animator;
    TouchingDirections touchingDirections;
    Damageable damageable;

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving 
    {
        get 
        {
            return _isMoving;
        } 
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }
    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight 
    {
        get
        {
            return _isFacingRight;
        } 
        private set
        {
            if (_isFacingRight != value)
            {
                //��תlocalScaleʹ��ɫ���򷴷���
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } 
    }

    private bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!damageable.LockVelocity)
        {
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        }

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);

        averageXSpeed = AverageXSpeed(CurrentMoveSpeed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //Face the Right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //Face the left
            IsFacingRight = false;
        }
    }

    //�˴����Ϸ�CurrentMoveSpeed��ͬ���ã�ʹ��x�����ϼ�ʹ�ڿ���Ҳ�ɽ���moveInput������ƶ�������������ҷ�����ɿ�����Զ�ĳ��ȣ�һֱ���Ű������Ҽ��������������룬�ڿ����ͷ����Ҽ��ᵼ�´�ֱ����
    float AverageXSpeed(float groundSpeed)
    {
        if (touchingDirections.IsGrounded)
        {
            speedCache[currentCacheIndex] = groundSpeed;
            currentCacheIndex++;
            currentCacheIndex %= CACHE_SIZE;
            float average = 0f;
            foreach(float speed in speedCache)
            {
                average += speed;
            }
            return average / CACHE_SIZE;
        }
        return groundSpeed;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //TODO:���Ҫ��ӽ�ɫ�Ƿ�����ж�����
        //�˴�started���µ���ɫ��ص��浫��Ծ����Ȼ���»��ý�ɫ�����ٶ�Ϊƽ��ֵ��״̬�����½�ɫ���ڿ����ƶ����ڵ����ٶȽϵ�
        //������԰��ٶ�ƽ��ֵ�ļ������OnJump�
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnRangedAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.rangedAttackTrigger);
        }
    }

    public void OnHit(int damage,Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
