extends Node2D

export (int) var number_of_dots = 5
export (Texture) var texture

var dots = []
var startPos
var startTime

var positions = [
	Vector2(200, 0),
	Vector2(0, -200),
	Vector2(-200, 0),
	Vector2(0, 200)
]

func _ready():
	for i in range(0, number_of_dots):
		var sprite = Sprite.new()
		
		sprite.texture = texture
		
		dots.append(sprite)
		add_child(sprite)
	
	startPos = global_position
	startTime = OS.get_ticks_msec()

func _physics_process(delta):
	var now = OS.get_ticks_msec()
	
	for i in range(0, dots.size()):
		var dot = dots[i]
		
		dot.global_position = easeOut(now - startTime, startPos, positions[0], 2000 * (i /4))
	
func easeOut(t, b, c, d):
	t /= float(d)
	
	return -c * t*(t-2) + b