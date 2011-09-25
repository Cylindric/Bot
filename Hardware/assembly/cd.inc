#ifndef(CD_Inc_Temp)
#declare CD_Inc_Temp=version;
#version 3.7;

#include "rune-cd.inc"

#declare CD_THICKNESS = 2;
#declare CD_NICE = false;

#macro CD()
    object {
        #if (CD_NICE)
            object{cd_object scale 60}
            
        #else
        
            difference {
                cylinder { 0, CD_THICKNESS*y, 60 }
                cylinder { -1*y, (CD_THICKNESS+1)*y, 7.5 }
                texture { pigment {color <0.3, 0.3, 0.5>} }
            }
    
        
        #end   
    }
#end

#ifndef(LIVE_SCENE)
global_settings{ assumed_gamma 1.0 }
#default{ finish{ ambient 0.1 diffuse 0.9 }} 
#include "tools.inc"

camera {
    location  <0, 150, -150>*0.7
    look_at <0, 0, 0>
}

Test_Sky()
Test_Ground()
CD()
#end

#version CD_Inc_Temp;
#end
