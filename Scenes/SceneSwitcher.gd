extends Node

var current_scene_path = null
var root_scene = "res://Scenes/Main/Main.tscn"
var history = []
var caller

func switch_scene(path):
	if current_scene_path:
		history.append(current_scene_path)

	current_scene_path = path
	get_tree().paused = false
	get_tree().change_scene(path)

func add_scene(instance):
	instance.pause_mode = Node.PAUSE_MODE_PROCESS
	get_tree().paused = true
	get_tree().get_root().add_child(instance)
	
	self.caller = caller

func remove_scene(scene):
	get_tree().paused = false
	get_tree().get_root().remove_child(scene)

func return_to_last():
    if not history.empty():
        var target = history.pop_back()
        get_tree().change_scene(target)
        current_scene_path = target
    elif current_scene_path:
        get_tree().change_scene(root_scene)
        current_scene_path = null