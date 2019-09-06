extends VBoxContainer

func _on_Start_pressed():
	SceneSwitcher.switch_scene("res://Scenes/Play/Play.tscn")

func _on_Settings_pressed():
	SceneSwitcher.switch_scene("res://Scenes/Settings/Settings.tscn")
