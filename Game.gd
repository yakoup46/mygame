extends Node2D

onready var ui = preload("res://UI.tscn")

func _ready():
	var node = ui.instance()
	
	node.get_node("Center Menu").visible = false
	node.get_node("Menu Button").visible = true
	
	get_node("UI Placeholder").add_child(node)
