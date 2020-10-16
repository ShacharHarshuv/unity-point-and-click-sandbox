using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class PlayerController : MonoBehaviour
{
    [SerializeField] public float targetPrecision = 1f;
    [SerializeField] public Transform locator;
    [SerializeField] public float minStepLength; 
    public int Direction => _spriteRenderer.flipX ? -1 : 1;

    public Vector3 Position
    {
        get
        {
            var locatorLocalPosition = locator.localPosition;
            var locatorLocalPositionInDirection = new Vector3(
                locatorLocalPosition.x * Direction,
                locatorLocalPosition.y,
                locatorLocalPosition.z);
            return transform.position + locatorLocalPositionInDirection;
        }
    }

    internal float TargetPosition = 0;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


    private bool IsWalking
    {
        get => _animator.GetBool(AnimationVariable.IsWalking);
        set { _animator.SetBool(AnimationVariable.IsWalking, value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentXPosition = Position.x;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickedPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Math.Abs(clickedPoint.x - currentXPosition) > minStepLength / 2)
            {
                TargetPosition = clickedPoint.x;
                _spriteRenderer.flipX = TargetPosition < currentXPosition;
                IsWalking = true;
            }
        }

        if (IsWalking)
        {
            bool isPassedTarget = TargetPosition * Direction - targetPrecision <= StopPosition * Direction; 
            if (isPassedTarget)
            {
                IsWalking = false;
            }
        }
    }
    
    // private void OnGUI()
    // {
    //     Debug.Log("OnGUI Stop Position: " + StopPosition);
    //     GUI.Label(new Rect(0,20, 200, 20),  "Position: " + Position.x);
    //     GUI.Label(new Rect(0,40, 200, 20),  "Stop position: " + StopPosition);
    //     GUI.Label(new Rect(0, 80, 200, 20), "target position: " + TargetPosition);
    // }
}