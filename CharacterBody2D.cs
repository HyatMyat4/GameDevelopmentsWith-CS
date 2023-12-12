using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public const float Speed = 300.0f;

	public string current_direction = "none";

	private AnimatedSprite2D animatedSprite;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	//public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();



	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Input handling for movement
		if (Input.IsActionPressed("ui_right"))
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("left_idle");
			current_direction = "right";
			velocity.X = Speed;
			velocity.Y = 0;
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			current_direction = "left";
			velocity.X = -Speed;
			velocity.Y = 0;
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("front_idle");
			current_direction = "down";
			velocity.Y = Speed;
			velocity.X = 0;
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("back_idle");
			current_direction = "up";
			velocity.Y = -Speed;
			velocity.X = 0;
		}
		else
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("idle");
			velocity.Y = 0;
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();


	}



}
