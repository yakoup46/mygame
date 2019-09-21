extends Control

func _on_Start_pressed():
	get_tree().change_scene("res://Scenes/Game.tscn")

func _on_Menu_Button_pressed():
	pause_mode = Node.PAUSE_MODE_PROCESS
	get_tree().paused = true
	
	get_node("Overlay Menu").visible = true
	get_node("Menu Button").visible = false

func _on_Back_pressed():
	get_node("Menu Button").visible = true
	get_node("Overlay Menu").visible = false
	
	get_tree().paused = false
	
func _on_Settings_pressed():
	get_node("Menu Button").visible = false
	get_node("Settings").visible = true

func _on_Close_pressed():
	get_node("Settings").visible = false

func _on_Quit_pressed():
	get_node("Overlay Menu").visible = false
	get_node("Center Menu").visible = true
	get_tree().change_scene("res://Scenes/UI.tscn")
	
	get_tree().paused = false

func _on_Reset_pressed():
	get_tree().change_scene("res://Scenes/Game.tscn")
	
	get_tree().paused = false
