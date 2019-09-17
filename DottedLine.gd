extends Node2D

onready var Tween = get_node("Tween")
onready var Dot = get_node("Dot")

var dots
var moving = 0
var dragging = false
var startPos
var normal = Vector2(1,1)

func _unhandled_input(event):
	if (event is InputEventMouseButton):
		if (event.pressed):
			dragging = true
			moveDots()
		
		if (!event.pressed):
			dragging = false
			stopDots()
		
func _ready():
	startPos = Dot.position
	dots = Dot.get_children()
	resetDots()
	
func _process(delta):
	if (dragging):
		normal = (get_local_mouse_position() - startPos).normalized()
	
func resetDots():
	for d in dots:
		d.position = startPos
		d.visible = false

func stopDots():
	resetDots()
	Tween.remove_all()

func moveDots():
	var mouse = get_local_mouse_position()
	
	for d in range(0, dots.size()):
		Tween.interpolate_method(dots[d], "method", dots[d].position, mouse, 1, 0, 0, d * .1)
		
	Tween.start()

func _on_Tween_tween_completed(object, key):
	object.visible = false

func _on_Tween_tween_started(object, key):
	object.visible = true
