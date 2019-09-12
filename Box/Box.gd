extends Node2D

# swiping dots script
# usage: put on the node, assign some circle texture, and viola!

# number of dots to be drawn
export var dot_number = 10;
export var dot_scale = 1.0;

# some parameter easing to break visual uniformness
export var dot_scale_ease = 1.5;
export var dot_pos_ease = 1.1;

# put circle texture here :3
export (Texture) var dot_texture = null;
export (Texture) var red_dot_texture = null;

# list for dot child objects
var dot_node = [];

# is swipe in progress or not
var swipe = false;

# aiming position, follows mouse position over time to make aim smooth
onready var aim_pos = global_position;

# max aiming range, in pixels
export var max_range = 320.0;

var anim_phase = 0.0;

var active = true

# animation time
export var time_aiming = 0.1;
export var time_fade_in = 0.1;
export var time_fade_out = 0.25;
export var time_scale = 0.05;
export var time_pos = 0.05;
export var time_anim = 0.5;

# init
func _ready():
	
	# spawn dot objects
	for i in range( dot_number + 1 ):
		
		# put object into the tree and onto the dot list
		var c = Sprite.new();
		add_child( c );
		dot_node.push_back( c );
		
		# assign parameters
		c.texture = dot_texture;
		c.scale = Vector2( 0, 0 );
		c.global_position = global_position;
		c.modulate.a = 0.0;

# update
func _process( delta ):
	# process some input
	swipe = Input.is_mouse_button_pressed( BUTTON_LEFT );
	
	anim_phase = fmod( anim_phase + delta/time_anim, 1.0 );
	
	# on swipe
	if( swipe && active):
		
		# move aiming position toward mouse position
		aim_pos = aim_pos*( 1 - delta/time_aiming ) + get_global_mouse_position()*delta/time_aiming;
		
		# update all dots on the list
		for i in range( dot_number + 1 ):
			
			# opacity and scale
			if( float( i )/dot_number < anim_phase ):
				dot_node[ i ].modulate.a = lerp( dot_node[ i ].modulate.a, 1, delta/time_fade_in );
			else:
				dot_node[ i ].modulate.a = lerp( dot_node[ i ].modulate.a, 0, delta/time_fade_out );
			dot_node[ i ].scale = dot_node[ i ].scale*( 1 - delta/time_scale ) + Vector2( 1, 1 )*dot_scale*( ease( float( i )/dot_number, dot_scale_ease ) )*delta/time_scale;
			
			var rigidbodyPos = get_node("RigidBody2D").global_position
			# position
			var off = aim_pos - rigidbodyPos;
			if( off.length() > max_range ):
				dot_node[ i ].texture = red_dot_texture
				off = off.normalized()*max_range
			else:
				dot_node[ i ].texture = dot_texture
			off *= ease( float( i )/dot_number, dot_pos_ease ); # << needs to be done this way, not up here. Believe me, otherwise it looks quite ugly and screwed up :3
			dot_node[ i ].global_position = dot_node[ i ].global_position*( 1 - delta/time_pos ) + ( rigidbodyPos + off )*delta/time_pos;
	
	# on stop swiping
	else:
		
		# move aiming position back to the origin
		aim_pos = aim_pos*( 1 - delta/time_aiming ) + global_position*delta/time_aiming;
		
		# update all dots on the list
		for i in range( dot_number + 1 ):
			dot_node[ i ].modulate.a = lerp( dot_node[ i ].modulate.a, 0, delta/time_fade_out );
			dot_node[ i ].scale = dot_node[ i ].scale*( 1 - delta/time_scale ) ;
			dot_node[ i ].global_position = dot_node[ i ].global_position*( 1 - delta/time_pos ) + global_position*delta/time_pos;
