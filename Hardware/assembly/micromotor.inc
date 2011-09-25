#ifndef(MicroMotor_Inc_Temp)
#declare MicroMotor_Inc_Temp=version;
#version 3.7;

#include "metals.inc"

#declare MICROMOT_HEIGHT = 10;
#declare MICROMOT_DIAMETER = 13;


#macro MicroMotor()

    #local TEX_BLACK_PVC = texture{pigment{colour rgb 0}}
    #local TEX_BODY = texture{pigment{color rgb 0.5}}
    #local TEX_BRASS = texture{T_Brass_3A}
    
    #local Radius = MICROMOT_DIAMETER * 0.5;

    object {
        union {
            // Body
            intersection {
                union {
                    cylinder { 0, 18*x, Radius texture{TEX_BODY}}
                    cylinder { 18*x, 20*x, Radius texture{TEX_BLACK_PVC}}
                    cylinder { 20*x, 21*x, 2 texture{TEX_BLACK_PVC}}
                }
                box { <-1, -MICROMOT_HEIGHT*0.5, -MICROMOT_HEIGHT>, <21, MICROMOT_HEIGHT*0.5, MICROMOT_HEIGHT>}
                cutaway_textures
            }
            
            // Gearbox
            union {
                box { <-10, -MICROMOT_HEIGHT*0.5, -Radius>, <-9, MICROMOT_HEIGHT*0.5, Radius>}
                box { <-4, -MICROMOT_HEIGHT*0.5, -Radius>, <-3, MICROMOT_HEIGHT*0.5, Radius>}
                box { <-1, -MICROMOT_HEIGHT*0.5, -Radius>, <0, MICROMOT_HEIGHT*0.5, Radius>}
                cylinder { -9*x, 0, 1 translate <0,-MICROMOT_HEIGHT*0.5+1,-Radius+1>}
                cylinder { -9*x, 0, 1 translate <0,-MICROMOT_HEIGHT*0.5+1,Radius-1>}
                cylinder { -9*x, 0, 1 translate <0,MICROMOT_HEIGHT*0.5-1,-Radius+1>}
                cylinder { -9*x, 0, 1 translate <0,MICROMOT_HEIGHT*0.5-1,Radius-1>}
                texture{TEX_BRASS}
            }
            
            // Spindle
            cylinder { -18*x, 22*x, 1.5 texture{TEX_BODY}}
            
        }
    }
#end

#ifndef(LIVE_SCENE)
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <-40, 150, -150>*0.4
    look_at <0, 0, 0>
}

Test_Sky()
Test_Origin()
MicroMotor()
object{MicroMotor() rotate 90*y translate <-30,0,10>}
object{MicroMotor() rotate -90*y translate <45,0,0>}
#end

#version MicroMotor_Inc_Temp;
#end
