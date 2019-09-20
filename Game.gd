extends Node2D

onready var ui = preload("res://UI.tscn")

var score = 0
var currentBox
var boxHolder
var boxes = []

func _ready():
	var node = ui.instance()
	
	node.get_node("Center Menu").visible = false
	node.get_node("Menu Button").visible = true
	
	get_node("UI Placeholder").add_child(node)
	
	currentBox = $Box
	boxHolder = $Box.duplicate()
	boxes.append($Box)
	
func _process(delta):
	#if ($Box.get_node("RigidBody2D").linear_velocity.y == 0 && $Box.get_node("RigidBody2D").angular_velocity == 0):
		#print($LandingZone.score)
	pass

func _physics_process(delta):
	score = 0
	
	for box in boxes:
		
		var inRed = isInside($LandingZone.get_node("Red"), box.get_node("RigidBody2D/Box"))
		var inGreen = isInside($LandingZone.get_node("Green"), box.get_node("RigidBody2D/Box"))
		var inYellow = isInside($LandingZone.get_node("Yellow"), box.get_node("RigidBody2D/Box"))
	
		if inRed:
			score = 1
			
		#if inYellow:
			#score = 2
		
		#if inGreen:
			#score = 3
	
		$Score.text = str("Score: ", score)
	
	if (currentBox.get_node("RigidBody2D").mode == RigidBody2D.MODE_RIGID):
		currentBox.active = false
		currentBox = boxHolder.duplicate()
		currentBox.get_node("RigidBody2D/CollisionShape2D").disabled = true
		boxes.append(currentBox)
		add_child(currentBox)
		
	if (score == 1):
		$LandingZone.get_node("Red").visible = true
		$Playground.visible = false
		
	if (score == 0):
		$LandingZone.get_node("Red").visible = false
		$Playground.visible = true
		
func isInside(area, box):
	var boxPos = box.global_position
	var areaPos = area.global_position
	var boxSize = box.get_node("CollisionShape2D").shape.extents * 2
	var areaSize = area.get_node("CollisionShape2D").shape.extents * 2
	
	var b0 = boxPos - (boxSize.y * Vector2(1, -1))/2
	var b1 = b0 + Vector2(0, -boxSize.y)
	var b2 = b0 + boxSize
	var b3 = b0 + Vector2(boxSize.x, 0)
	
	var a0 = areaPos - (areaSize.y * Vector2(1, -1))/2
	var a1 = a0 + Vector2(0, -areaSize.y)
	var a2 = a0 + areaSize
	var a3 = a0 + Vector2(areaSize.x, 0)
	
	if (b0 < a0 || b1.y < a1.y || b2.y > a2.y || b3 > a3):
		return false
	
	return true
	