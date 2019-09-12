extends Node2D

export (Texture) var texture;

onready var Tween = get_node("Tween")

var sprite
var startPos

var moveTo = Vector2(100, 0)

var time_start = 0
var time_now = 0

func _ready():
	sprite = Sprite.new()
	sprite.texture = texture
		
	add_child(sprite)
	time_start = OS.get_unix_time()
	startPos = 1
	
func _physics_process(delta):
	var elapsed = OS.get_unix_time() - time_start
	startPos = easeInQuad(elapsed, 2, startPos, 2)
	
	if (elapsed <= 2):
		sprite.global_position = sprite.global_position + Vector2(10, 0) * delta * startPos
#	startPos = eastOut(OS.get_unix_time() - time_start, startPos, 10, .25)
#	if (startPos > 0):
#		print(startPos)
#
#	if (startPos > 0):
	
	

# time, start val, chang in val, duration
func easeInQuad(t, b, c, d):
	t /= d;
	return c*t*t + b
