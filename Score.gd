extends Node2D

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

export (Texture) var texture

var dots = []
var startTime
var startPos
var endPos
var leader
var index = 0

var positions = [
	Vector2(100, 0),
	Vector2(100, -100),
	Vector2(0, -100),
	Vector2(0, 0)
];

# Called when the node enters the scene tree for the first time.
func _ready():
	
	for i in range(0, 4):
		var sprite = Sprite.new()
		dots.append(sprite)
	
		sprite.texture = texture
		sprite.global_position = global_position
		
		add_child(sprite)
	
	startTime = OS.get_ticks_msec()
	startPos = dots[0].global_position
	endPos = startPos + Vector2(100, 0)
	
	for i in range(0, 3):
		positions[i] += startPos
	
func _physics_process(delta):
	var now = OS.get_ticks_msec()
	var elapsed = now - startTime
	var leader = positions[index]
	
	print(leader)
	
	for i in range(0, 4):
		var dot = dots[i]
		
		dot.global_position += (leader - dot.global_position) * .1
		leader = dot.global_position
	
	if (leader.ceil() == positions[index]):
		leader = positions[index]
		var newIndex = index + 1
		
		if (newIndex < 4):
			index = newIndex
		else:
			index = 0

func linearTween(t, b, c, d):
	return c * t / float(d) + b
