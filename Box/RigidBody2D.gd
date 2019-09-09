extends RigidBody2D

var startPos = Vector2()

func _input(event):
	if (event is InputEventScreenTouch or event is InputEventMouseButton):
		if (event.pressed):
			
			startPos = get_global_mouse_position()
		
		if (!event.pressed):
			var dir = (get_global_mouse_position() - startPos)
			
			mode = RigidBody2D.MODE_RIGID
			apply_central_impulse(Vector2(dir.x, -sqrt(abs(dir.y*2000))))
