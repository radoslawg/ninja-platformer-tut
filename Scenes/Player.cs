// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Org.Grzanka.NinjaGame;

using Godot;

public partial class Player : CharacterBody2D
{
    private AnimationPlayer _animationPlayerUpper;
    private AnimationPlayer _animationPlayerLower;
    private Node2D _sprite;

    [Export]
    public int Speed { get; set; } = 50;

    [Export]
    public int JumpSpeed { get; set; } = 200;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _animationPlayerUpper = GetNode<AnimationPlayer>("AnimationPlayerUpper");
        _animationPlayerLower = GetNode<AnimationPlayer>("AnimationPlayerLower");
        _sprite = GetNode<Node2D>("Sprite");
        base._Ready();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        float direction = Input.GetAxis("ui_left", "ui_right");

        if (!IsOnFloor())
        {
            Velocity += Vector2.Down * GetGravity() * (float)delta;
        }

        Velocity = Velocity with { X = direction * Speed };

        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        {
            Velocity = Velocity with { Y = -JumpSpeed };
        }

        if (Velocity.X < 0)
        {
            _sprite.Scale = _sprite.Scale with { X = -1 };
        }
        else if (Velocity.X > 0)
        {
            _sprite.Scale = _sprite.Scale with { X = 1 };
        }

        if (direction != 0)
        {
            _animationPlayerLower.Play("run");
            _animationPlayerUpper.Play("run");
        }
        else
        {
            _animationPlayerLower.Play("idle");
            _animationPlayerUpper.Play("idle");
        }

        if (!IsOnFloor())
        {
            _animationPlayerLower.Play("jump");
            _animationPlayerUpper.Play("jump");
        }

        MoveAndSlide();
        base._PhysicsProcess(delta);
    }
}
