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

var atPos = 0

export (int) var number_of_dots = 5

var dots = []

func _ready():
	for i in range(0, number_of_dots):
		var node = TweenNode.new(texture, position, i)
		node.delay = i * 150

		dots.append(node)
		add_child(node.sprite)

		#set_state(node)

func _physics_process(delta):
	
	for i in range(0, number_of_dots):
		var dot = dots[i]
		
		dot.move_to(delta)
	
	#print("MOVED")
	
func easeOut(t, b, c, d):
	t /= float(d)

	return -c * t*(t-2) + b
	
func linear(t, b, c, d):
	return c*t/float(d) + b;

func set_state(obj):
	#start = dots[0].sprite.position
	#startTime = OS.get_ticks_msec()
	#change = positions[atPos]
	
	#obj.start = obj.sprite.position
	#obj.change = positions[obj.atPos]
	#obj.startTime = OS.get_ticks_msec()
	
	#obj.atPos += 1
	
	#if (obj.atPos > 3):
	#	obj.atPos = 0
	pass

func progress():
	pass

func complete(obj):
	obj.delay = 0
	set_state(obj)
	
#	obj.tween_running = false
#
#	var running = false
#
#	for d in dots:
#		if (d.tween_running == true):
#			running = true
#			break
#
#	if (!running):
#		atPos += 1
#
#		if (atPos > 3):
#			atPos = 0
#
#		set_state()
#
#		for d in dots:
#			d.tween_running = true

func tween(obj, duration, easingFunc, onProgress, onComplete):
	var time = OS.get_ticks_msec() - obj.startTime
	
	if (time < duration):
		obj.sprite.position = easingFunc.call_func(time, obj.start, obj.change, duration)
		onProgress.call_func()
	else:
		time = duration
		obj.sprite.position = easingFunc.call_func(time, obj.start, obj.change, duration)
		onComplete.call_func(obj)
	
	
