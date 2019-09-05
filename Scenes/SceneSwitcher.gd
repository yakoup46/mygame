extends Node

var current_scene_path = null
var root_scene = "res://Scenes/Main/Main.tscn"
var history = []

func switch_scene(path):
    if current_scene_path:
        history.append(current_scene_path)

    current_scene_path = path
    get_tree().change_scene(path)

func return_to_last():
    if not history.empty():
        var target = history.pop_back()
        get_tree().change_scene(target)
        current_scene_path = target
    elif current_scene_path:
        get_tree().change_scene(root_scene)
        current_scene_path = null