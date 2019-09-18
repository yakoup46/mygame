extends RigidBody2D

var startPos = Vector2()
var window
var active = true
var targetRes = Vector2(1440, 2880)

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
			
			if (dir.length() > 100):
				dir = dir.clamped(1000)
				mode = RigidBody2D.MODE_RIGID
				get_node("CollisionShape2D").disabled = false
			
			#var extra = 2000 + ((1 - (window.x/float(1440))) * 2000)
			#print(extra)
			
				apply_central_impulse(Vector2(dir.x, -sqrt(abs(dir.y*(8000)))))
				angular_velocity = dir.normalized().x

func _physics_process(delta):
	pass
