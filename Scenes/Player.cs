// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Org.Grzanka.NinjaGame;

using System.Runtime.InteropServices;
using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 50;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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
        Velocity = Vector2.Right * direction * Speed;
        MoveAndSlide();
        base._PhysicsProcess(delta);
    }
}
