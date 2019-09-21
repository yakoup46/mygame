tool
extends Node2D

export (Color) var color
export (int) var thickness
export (Vector2) var size
export (int) var points

var score = 0

func _ready():
	print("ready")

func _draw():
	print("draw")
	draw_line(Vector2(0, 0), Vector2(size.x + thickness/2, 0), color, thickness, true)
	draw_line(Vector2(size.x, 0), Vector2(size.x, size.y + thickness/2), color, thickness, true)
	draw_line(Vector2(size.x, size.y), Vector2(0 - thickness/2, size.y), color, thickness, true)
	draw_line(Vector2(0, size.y), Vector2(0, -thickness/2), color, thickness, true)
	
	var area = Area2D.new()
	area.name = "Area2D"
	area.global_position = (global_position - position) + (size / 2)
	
	var collision = CollisionShape2D.new()
	collision.name = "CollisionShape2D"
	collision.shape = RectangleShape2D.new()
	collision.shape.extents = (size + Vector2(thickness, thickness)) / 2
	
	area.add_child(collision)
	
	add_child(area)
	