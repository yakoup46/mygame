extends Control

onready var PopupMenu = preload("res://Scenes/PopupMenu/PopupMenu.tscn")

func _on_Button_pressed():
	 get_tree().get_root().add_child(PopupMenu.instance())
