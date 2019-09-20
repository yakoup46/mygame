class_name TweenNode

# Member Variables

var tween_running = true
var sprite

# Constants

# Enums

func _init(texture, position):
	sprite = Sprite.new()
	sprite.texture = texture
	sprite.global_position = position
