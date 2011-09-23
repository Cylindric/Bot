#ifndef(Hex_Spacer_Inc_Temp)
#declare Hex_Spacer_Inc_Temp=version;
#version 3.7;

#include "shapes.inc"
#include "shapes2.inc"

#macro HexSpacer(Diameter, Length)

    difference {
        object{
            Hexagon
            scale <Length*0.5, Diameter*0.8, Diameter*0.8>
            translate Length*0.5*x
        }
        cylinder{-1*x, (Length+1)*x, Diameter*0.5}

        rotate 90*z
        texture { pigment {color <1,1,0.8>} }
    }

#end

#ifndef(LIVE_SCENE)
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <10, 40, -20>*0.5
    look_at <4, 5, 0>
}

Test_Sky()
Test_Ground()
object{HexSpacer(2, 5) translate -5*x}
object{HexSpacer(3, 8)}
object{HexSpacer(4, 12) translate 7*x}
#end

#version Hex_Spacer_Inc_Temp;
#end
