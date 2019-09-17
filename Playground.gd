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

var dots = []

func _ready():
	for d in number_of_dots:
		var node = TweenNode.new(texture, position)

		dots.append(node)
		add_child(node.sprite)

	set_state()

func _physics_process(delta):
	for i in range(0, dots.size()):
		var dot = dots[i]
		
		tween(dot, 250 * (i + 1), funcref(self, "easeOut"), funcref(self, "progress"), funcref(self, "complete"))


func easeOut(t, b, c, d):
	t /= float(d)

	return -c * t*(t-2) + b

func set_state():
	start = dots[0].sprite.position
	startTime = OS.get_ticks_msec()
	change = positions[atPos]

func progress():
	pass

func complete(obj):
	obj.tween_running = false

	var running = false

	for d in dots:
		if (d.tween_running == true):
			running = true
			break

	if (!running):
		atPos += 1

		if (atPos > 3):
			atPos = 0

		set_state()

		for d in dots:
			d.tween_running = true

func tween(obj, duration, easingFunc, onProgress, onComplete):
	var time = OS.get_ticks_msec() - startTime

	if (time < duration):
		obj.sprite.position = easingFunc.call_func(time, start, change, duration)
		onProgress.call_func()
	else:
		time = duration
		obj.sprite.position = easingFunc.call_func(time, start, change, duration)
		onComplete.call_func(obj)
