extends Control

onready var PopupMenu = preload("res://Scenes/PopupMenu/PopupMenu.tscn")

func _on_Button_pressed():
	SceneSwitcher.add_scene(PopupMenu.instance())
