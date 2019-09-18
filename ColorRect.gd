extends ColorRect

var start = OS.get_ticks_msec()

var change = 0.005
var current = 0.2

func _ready():
	#screen
	#margin_right = 
	#margin_bottom =
	set_physics_process(false)
	pass

func _physics_process(delta):
	var time = OS.get_ticks_msec() - start
	var alpha = easeOut(time, current, change, 250)
	
	print(alpha)
	
	if (time < 2000):
		color = ColorN("red", alpha)
	else:
		start = OS.get_ticks_msec()
		current = alpha
		change *= -1
	
func easeOut(t, b, c, d):
	t /= float(d)

	return c * t*(t-2) + b