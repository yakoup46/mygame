extends Control

func _ready():
	var file = File.new()
	
	if (file.file_exists("user://settings.save")):
		file.open("user://settings.save", File.READ)
		
		var settings = parse_json(file.get_line())
	
		get_node("Settings/VBoxContainer/Gravity/LineEdit").text = settings['g']
		get_node("Settings/VBoxContainer/Power/LineEdit").text = settings['p']
		get_node("Settings/VBoxContainer/Bounce/LineEdit").text = settings['b']
		get_node("Settings/VBoxContainer/Friction/LineEdit").text = settings['f']

func _on_Start_pressed():
	LevelManager.load_level()

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
	var settings = File.new()
	settings.open("user://settings.save", File.WRITE)
	
	var data = {}
	
	data['g'] = get_node("Settings/VBoxContainer/Gravity/LineEdit").text
	data['p'] = get_node("Settings/VBoxContainer/Power/LineEdit").text
	data['b'] = get_node("Settings/VBoxContainer/Bounce/LineEdit").text
	data['f'] = get_node("Settings/VBoxContainer/Friction/LineEdit").text
	
	settings.store_line(to_json(data))
	settings.close()
	
	get_node("Settings").visible = false

func _on_Quit_pressed():
	get_node("Overlay Menu").visible = false
	get_node("Center Menu").visible = true
	get_tree().change_scene("res://Scenes/UI.tscn")
	
	get_tree().paused = false

func _on_Reset_pressed():
	LevelManager.load_level()
	
	get_tree().paused = false

func _on_Next_pressed():
	LevelManager.level += 1
	LevelManager.load_level()
	pass # Replace with function body.
