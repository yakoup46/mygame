extends Node2D

export (Texture) var texture

var sprite
var sprite2
var start
var startTime
var change

var spriteDone = false
var sprite2Done = false

var spritesDone = 0

var positions = [
	Vector2(200, 0),
	Vector2(0, 200),
	Vector2(-200, 0),
	Vector2(0, -200)
]

var atPos = 0

export (int) var number_of_dots = 5

var nodes = []

func _ready():
	for d in dots:
		nodes.append(TweenNode.new())
	sprite = Sprite.new()

	sprite.texture = texture
	sprite.global_position = global_position
	sprite.name = "one"

	sprite2 = Sprite.new()

	sprite2.texture = texture
	sprite2.global_position = global_position
	sprite2.name = "two"

	add_child(sprite)
	add_child(sprite2)
	set_state()

func _physics_process(delta):
	tween(sprite, 250, funcref(self, "easeOut"), funcref(self, "progress"), funcref(self, "complete"))
	tween(sprite2, 500, funcref(self, "easeOut"), funcref(self, "progress"), funcref(self, "complete"))
	pass

func easeOut(t, b, c, d):
	t /= float(d)

	return -c * t*(t-2) + b

func set_state():
	start = sprite.global_position
	startTime = OS.get_ticks_msec()
	change = positions[atPos]

func progress():
	pass

func complete(obj):
	if (obj.name == "one"):
		if (!spriteDone):
			spritesDone += 1
			spriteDone = true
	if (obj.name == "two"):
		if (!sprite2Done):
			spritesDone += 1
			sprite2Done = true

	if (spritesDone == 2):
		atPos += 1

		if (atPos > 3):
			atPos = 0

		set_state()
		spritesDone = 0
		spriteDone = false
		sprite2Done = false

func tween(obj, duration, easingFunc, onProgress, onComplete):
	var time = OS.get_ticks_msec() - startTime

	if (time < duration):
		obj.global_position = easingFunc.call_func(time, start, change, duration)
		onProgress.call_func()
	else:
		time = duration
		obj.global_position = easingFunc.call_func(time, start, change, duration)
		onComplete.call_func(obj)
