extends Node

var level = 1
var last_level = 2

func load_level():
	if (level <= last_level):
		get_tree().change_scene(str("res://Levels/Level", level, ".tscn"))