#ifndef(Nut_Inc_Temp)
#declare Nut_Inc_Temp=version;
#version 3.7;

#include "shapes.inc"
#include "shapes2.inc"

#macro Nut(Diameter)

    difference {
        object{
            Hexagon
            scale <0.25, 0.8, 0.8>
            translate 0.25*x
        }
        cylinder{-1*x, 1*x, 0.5}

        rotate 90*z
        scale Diameter
        texture { pigment {color <1,0,0>} }
    }

#end


#ifndef(LIVE_SCENE)
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <5, 10, -10>
    look_at <3, 0, 0>
}

Test_Sky()
Test_Ground()
object{Nut(2) translate -5*x}
object{Nut(3)}
object{Nut(4) translate 7*x}
#end

#version Nut_Inc_Temp;
#end
