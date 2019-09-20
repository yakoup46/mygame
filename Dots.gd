extends Node2D

export (Texture) var circle

var sprite

var glow
var noglow

var dots = []
var onDot = 0
var mDot

var _timer

func _ready():
	glow = CanvasItemMaterial.new()
	glow.blend_mode = BLEND_MODE_ADD
	
	noglow = CanvasItemMaterial.new()
	noglow.blend_mode = BLEND_MODE_DISABLED
	
	sprite = Sprite.new()
	sprite.texture = circle
	sprite.material = glow
	
	_timer = Timer.new()
	add_child(_timer)

	_timer.connect("timeout", self, "_on_Timer_timeout")
	_timer.set_wait_time(0.05)
	_timer.set_one_shot(false) # Make sure it loops
	_timer.start()
	
	build_box()
	pass
	
func _on_Timer_timeout():
	mDot.position = dots[onDot].position
#	var lastDot = dots[onDot - 1]
#	var dot = dots[onDot]
#
#	if (dot.material.blend_mode == BLEND_MODE_ADD):
#		dot.material = noglow
#		lastDot.material = glow
#	else:
#		dot.material = glow
#		lastDot.material = noglow
#
	onDot += 1
#
	if (onDot >= dots.size()):
		onDot = 0
	
func build_box():
	for i in range(0, 10):
		var c = sprite.duplicate()
		
		c.position = Vector2(i * 25, 0)
		add_child(c)
		dots.append(c)
	
	for i in range(0, 10):
		var c = sprite.duplicate()
		
		c.position = Vector2(250, i * 25)
		add_child(c)
		dots.append(c)
	
	for i in range(0, 10):
		var c = sprite.duplicate()
		
		c.position = Vector2(225 - (i * 25), 225)
		add_child(c)
		dots.append(c)
		
	for i in range(1, 9):
		var c = sprite.duplicate()
		
		c.position = Vector2(0, 225 - (i * 25))
		add_child(c)
		dots.append(c)
	
	mDot = sprite.duplicate()
	mDot.position = Vector2(0,0)
	mDot.modulate = Color.green
	add_child(mDot)