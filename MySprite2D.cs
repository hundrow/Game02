using Godot;
using System;


public partial class MySprite2D : Sprite2D
{
	private int _speed = 400;
	private float _angularSpeed = Mathf.Pi;
	private float _wheelPosition = 0;
	private Sprite2D leftWheel, rightWheel;
	private const float _maxWheelRotation = 0.523599f;
	private float _currentWheelRotation = 0;
	
	public override void _Ready(){
		var timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
		leftWheel = GetNode<Sprite2D>("leftWheel");
		rightWheel = GetNode<Sprite2D>("rightWheel");
	}
	
	public override void _Process(double delta)
{
	Rotation += _angularSpeed * (float)delta;
	var velocity = Vector2.Up.Rotated(Rotation) * _speed;
	Position += velocity * (float)delta;
}
	//public override void _Process(double delta){
		//var direction = 0;
		//if(Input.IsActionPressed("ui_left") && _currentWheelRotation > -_maxWheelRotation){
			//float rotationThisFrame = _angularSpeed * (float)delta;
			//leftWheel.Rotation -= rotationThisFrame;
			//rightWheel.Rotation -= rotationThisFrame;
			//_currentWheelRotation -= rotationThisFrame;
		//}
		//if(Input.IsActionPressed("ui_right") && _currentWheelRotation < _maxWheelRotation){
			//float rotationThisFrame = _angularSpeed * (float)delta;
			//leftWheel.Rotation += rotationThisFrame;
			//rightWheel.Rotation += rotationThisFrame;
			//_currentWheelRotation += rotationThisFrame;
		//}
//
		//
		//var velocity = Vector2.Zero;
		//if(Input.IsActionPressed("ui_up")){
			//velocity = Vector2.Up.Rotated(Rotation) * _speed;
			//Rotation += _angularSpeed * _currentWheelRotation * (float)delta;
		//}
		//if(Input.IsActionPressed("ui_down")){
			//velocity = Vector2.Down.Rotated(Rotation) * _speed;
			//Rotation -= _angularSpeed * _currentWheelRotation * (float)delta;
		//}
		//Position += velocity * (float)delta;
	//}
	private void _on_button_pressed(){
		SetProcess(!IsProcessing());
	}
	private void OnTimerTimeout(){
		Visible = !Visible;
	}
}




