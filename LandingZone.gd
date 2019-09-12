extends Node2D

var score = 0

func _on_Red_area_entered(area):
	if (area.name == "Box"):
		score = 1

func _on_Yellow_area_entered(area):
	if (area.name == "Box"):
		score = 2

func _on_Green_area_entered(area):
	if (area.name == "Box"):
		score = 3
		