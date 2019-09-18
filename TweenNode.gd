class_name TweenNode

# Member Variables

var tween_running = true
var sprite
var delay
var last
var change
var startTime = 0
var atPos = 0
var offset

var positions = [
	Vector2(0, -350),
	Vector2(350, -350),
	Vector2(350, 0),
	Vector2(0, 0)
]

# Constants

# Enums


func _init(texture, position, i):
	sprite = Sprite.new()
	sprite.texture = texture
	sprite.position = Vector2(0, i * -50)
	
func move_to(d):
	var distance = sprite.position.distance_to(positions[atPos])
	var direction = sprite.position.direction_to(positions[atPos])
	
	if (distance > 3):
		sprite.position += direction * d * 750
	else:
		sprite.position = positions[atPos]
		
		atPos += 1
		
		if (atPos > 3):
			atPos = 0