extends Node2D

onready var ui = preload("res://Scenes/UI.tscn")

export (int) var level_number

var score = 0
var currentBox
var boxHolder
var boxes = []
var ui_node

func _ready():
	ui_node = ui.instance()
	
	ui_node.get_node("Center Menu").visible = false
	ui_node.get_node("Menu Button").visible = true
	
	get_node("UI Placeholder").add_child(ui_node)
	
	currentBox = $Box
	boxHolder = $Box.duplicate()
	boxes.append($Box)

func _physics_process(delta):
	score = 0
	
	for zone in $Zones.get_children():
		for box in boxes:
			if (zone.get_node("Area2D") != null):
				var goal = isInside(zone.get_node("Area2D"), box.get_node("RigidBody2D/Box"))
			
				if (goal):
					print(zone.points)
					score = zone.points
#
	$Score.text = str("Score: ", score)
	
	if (score > 0):
		var all_at_rest = true
		
		for box in boxes:
			if (!box.get_node("RigidBody2D").at_rest):
				all_at_rest = false
				break
		
		if (all_at_rest):
			ui_node.get_node("Level").visible = true
			
			if (LevelManager.last_level == LevelManager.level):
				ui_node.get_node("Level").get_node("Next Level/Label").text = str("Score: ", score, "\n YOU WON! GAME OVER!")
				ui_node.get_node("Level/Next Level/Next").visible = false
			else:
				ui_node.get_node("Level").get_node("Next Level/Label").text = str("Score: ", score)
#
	if (currentBox.get_node("RigidBody2D").mode == RigidBody2D.MODE_RIGID):
		currentBox.active = false
		currentBox = boxHolder.duplicate()
		currentBox.get_node("RigidBody2D/CollisionShape2D").disabled = true
		boxes.append(currentBox)
		add_child(currentBox)
		
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
	