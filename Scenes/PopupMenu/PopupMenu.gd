extends Control

onready var Settings = preload("res://Scenes/Settings/Settings.tscn")


func _on_Back_pressed():
	SceneSwitcher.remove_scene(self)

func _on_Quit_pressed():
	queue_free()
	SceneSwitcher.switch_scene("res://Scenes/Main/Main.tscn")

func _on_Settings_pressed():
	queue_free()
	SceneSwitcher.add_scene(Settings.instance())
