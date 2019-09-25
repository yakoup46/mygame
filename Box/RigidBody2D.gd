extends RigidBody2D

var startPos = Vector2()
var window
var active = true
var targetRes = Vector2(1440, 2880)
var at_rest = false

func _ready():
	window = OS.get_real_window_size()

func _input(event):
	if (!get_parent().active):
		return
		
	if (event is InputEventScreenTouch and mode == RigidBody2D.MODE_STATIC):
		if (event.pressed):
			startPos = event.position
		
		if (!event.pressed):
			var dir = event.position - startPos
			
			if (dir.length() > 100):
				dir = dir.clamped(1000)
				mode = RigidBody2D.MODE_RIGID
				get_node("CollisionShape2D").disabled = false
			
				apply_central_impulse(Vector2(dir.x * 2, -sqrt(abs(dir.y*(10000)))))
				angular_velocity = dir.normalized().x

func _physics_process(delta):
	print(linear_velocity.abs() < Vector2(5, 5))
	if linear_velocity.abs() < Vector2(5, 5):
		at_rest = true
	else:
		at_rest = false
	pass
