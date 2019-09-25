tool
extends Node2D

export (Texture) var left
export (Texture) var right
export (Texture) var middle
export (int) var tile_count = 1 setget set_tile_count
export (float) var platform_scale = 1 setget set_platform_scale

var left_node
var right_node
var middle_nodes = []

var cliff
var collision 

func _ready():
	cliff = get_node("RigidBody2D/Cliff")
	
	left_node = Sprite.new()
	right_node = Sprite.new()
	
	left_node.texture = left
	right_node.texture = right
	
	left_node.position = position - global_position
	
	cliff.add_child(left_node)
	cliff.add_child(right_node)
	
	for i in range(0, tile_count):
		var sprite = Sprite.new()
		sprite.texture = middle
		
		middle_nodes.append(sprite)
		cliff.add_child(sprite)
		
		sprite.position.x = left_node.position.x + left_node.texture.get_size().x + (middle_nodes.back().texture.get_size().x * i)
		
	right_node.position.x = middle_nodes.back().position.x + middle_nodes.back().texture.get_size().x
	
	scale = Vector2(platform_scale, platform_scale)
	
	collision = CollisionShape2D.new()
	var shape = RectangleShape2D.new()
	
	collision.shape = shape
	get_node("RigidBody2D").add_child(collision)
	
	collision.shape.extents = (Vector2(cliff.get_child_count() * left_node.texture.get_size().x, left_node.texture.get_size().y)) / 2
	collision.position = cliff.get_child(0).position + collision.shape.extents - left_node.texture.get_size() / 2

func set_tile_count(value):
	tile_count = value
	
	if (cliff):
		for n in cliff.get_children():
			cliff.remove_child(n)
	
	if (collision):
		get_node("RigidBody2D").remove_child(collision)
	
		_ready()
	
func set_platform_scale(value):
	platform_scale = value
	
	scale = Vector2(platform_scale, platform_scale)