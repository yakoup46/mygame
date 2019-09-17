class_name TweenNode

# Member Variables

var tweem_running = false
var sprite

# Constants

# Enums

func _init():
	sprite = Sprite.new()
	sprite.texture = texture
	sprite.global_position = global_position
