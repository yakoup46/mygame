extends RigidBody2D

var startPos = Vector2()
var window
var active = true

func _ready():
	window = OS.get_real_window_size()

func _input(event):
	if (!get_parent().active):
		return
		
	if (event is InputEventScreenTouch or event is InputEventMouseButton and mode == RigidBody2D.MODE_STATIC):
		if (event.pressed):
			
			startPos = get_global_mouse_position()
		
		if (!event.pressed):
			var dir = (get_global_mouse_position() - startPos)
			
			mode = RigidBody2D.MODE_RIGID
			get_node("CollisionShape2D").disabled = false
			apply_central_impulse(Vector2(dir.x, -sqrt(abs(dir.y*(2000 + (2880 - window.y))))))

func _physics_process(delta):
	pass

func _on_RigidBody2D_body_entered(body):
	if (body.get_parent().name == 'Box'):
		bounce = 0
		body.bounce = 0
