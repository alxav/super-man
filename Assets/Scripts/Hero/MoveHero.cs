using UnityEngine;

[RequireComponent(typeof(Rotation))]
[RequireComponent(typeof(AnimatorHero))]
public class MoveHero : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private floatVariable speed;
    
    private Transform _transform;
    private Rotation rotation;
    private AnimatorHero animatorHero;
    private Vector2 distance;
    
    void Awake()
    {
        _transform = transform;
        animatorHero = GetComponent<AnimatorHero>();
        rotation = GetComponent<Rotation>();
    }

    private void Start()
    {
        SetTarget(new Vector2(0, 1));
        MoveTarget();
    }

    void Update()
    {
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            animatorHero.Idle();
            return;
        }
        
        animatorHero.Fly();
        
        MoveTarget();
        
        SetTarget(joystick.Direction);

        var value = GetValue();
        rotation.ApplyAxis(value);
    }
    
    public void SetTarget(Vector2 value)
    {
        distance = value;
    }
    
    private void MoveTarget()
    {
        
        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + _transform.forward,
            Time.deltaTime * speed.Value);
    }
    
    private float GetValue()
    {
        var x = distance.x;
        var y = distance.y;

        if (y > 0) return x;

        return 1 + Mathf.Abs(x - 1);
    }
    
}