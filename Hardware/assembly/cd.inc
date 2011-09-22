#declare CD_THICKNESS = 2;

#declare CD = object {
    difference {
        cylinder { 0, CD_THICKNESS*y, 60 }
        cylinder { -1*y, (CD_THICKNESS+1)*y, 7.5 }
        texture { pigment {color <0.3, 0.3, 0.5, 0.99>} }
        
    }
}

#ifndef(LIVE_SCENE)
#version 3.7;
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <0, 150, -150>*0.7
    look_at <0, 0, 0>
}

Test_Sky()
Test_Ground()
CD
#end