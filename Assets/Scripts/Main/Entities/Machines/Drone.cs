using SkillSystem;
using UnityEngine;

[RequireComponent(typeof(SkillUser), typeof(Rigidbody2D))]

public class Drone : Machine
{
    public HorizontalDash horizontalDash;
    public VerticalImpulse verticalDash;
    public Shoot shootSkill;

    private SkillUser _skillUser;
    private Rigidbody2D _rb2D;

    void Awake()
    {
        _skillUser = GetComponent<SkillUser>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Asignar las dependencias
        horizontalDash.Rb2D = _rb2D;
        verticalDash.Rb2D = _rb2D;

        _skillUser.AddSkill(horizontalDash);
        _skillUser.AddSkill(verticalDash);
        _skillUser.AddSkill(shootSkill);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalDash.SetDirection(1);
            _skillUser.UseSkill<VerticalImpulse>();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            verticalDash.SetDirection(-1);
            _skillUser.UseSkill<VerticalImpulse>();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalDash.SetDirection(1);
            _skillUser.UseSkill<HorizontalDash>();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalDash.SetDirection(-1);
            _skillUser.UseSkill<HorizontalDash>();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _skillUser.UseSkill<Shoot>();
        }
    }
}
