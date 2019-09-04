extends Control

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_Back_pressed():
	queue_free()

func _on_Quit_pressed():
	queue_free()
	SceneSwitcher.switch_scene("res://Scenes/Main/Main.tscn")

func _on_Settings_pressed():
	queue_free()
	SceneSwitcher.switch_scene("res://Scenes/Settings/Settings.tscn")
