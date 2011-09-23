/*************************************************************************
              CD INCLUDE FILE FOR PERSISTENCE OF VISION 3.1
**************************************************************************

Created by Rune S. Johansen, July 12 1999

E-mail: rune.johansen@get2net.dk
(please check my website if the e-mail address isn't valid anymore)

Website: http://welcome.to/rsj

See the sample scene "cd.pov" for more information.

*************************************************************************/


// Default samples per color cycle.
#ifndef (cd_samples)
#declare cd_samples    = 9.0;
#end
// Default phong value
#ifndef (cd_phong)
#declare cd_phong      = 1.0;
#end
// Default phong_size value
#ifndef (cd_phong_size)
#declare cd_phong_size = 200;
#end
// Default frequency of color cycles in unknown units.
#ifndef (cd_dispertion)
#declare cd_dispertion = 1.5;
#end
// Default offset of color cycles in color cycles.
#ifndef (cd_offset)
#declare cd_offset     = 0.5;
#end
// Default number of color cycles.
#ifndef (cd_cycles)
#declare cd_cycles     = 5.0;
#end
// Default scale of cd texture
#ifndef (cd_scale)
#declare cd_scale = 2;
#end
// Default texture on front of the cd.
#ifndef (cd_front_texture)
#declare cd_front_texture =
texture {
   pigment {color blue 1}
   finish {phong 1}
}
#end

// Calculates how many samples will be
// used for values below cd_offset.
#declare _cd_unused = cd_samples*cd_offset;
#declare _cd_unused =
(_cd_unused=int(_cd_unused)?_cd_unused:ceil(_cd_unused));

// (Zero To One) macro which rounds towards
// the nearest value between 0 and 1.
#macro zto (P) (P<0?0:(P>1?1:P)) #end 

// The cd texture is a average of many textures
// with different colored highlights.
#declare cd_texture =
texture {
   average
   texture_map {

// This texture contains the reflective
// surface and the regular highlight.
[
   pigment {rgb 0}
   finish {
      ambient 0
      diffuse 0
      reflection cd_samples*2*cd_cycles+1
      //phong cd_phong*cd_samples*2*cd_cycles+1
      //phong_size cd_phong_size
   }
]

// Some formulas which calculates the colored
// highlights. The formulas are optimised for
// realism but they are not based on real physics
// at all. 
// A is a counter in the primary while_loop.
// B and C are some modified versions of the
// counter.
#declare A = 0;
#while (A<cd_cycles+cd_offset)
   #declare B = A-cd_offset;
   
   // We don't want the indifferent values below
   // the offset value to have any texture_map
   // entries.
   #if (B>=0)
      
      #ifndef (Control)        // The first time
         #declare B_value = B; // this code
         #declare Control = 1; // is accessed
      #end                     // the B value
      #declare B = B-B_value;  // is reset.
      
      // The first color cycle have full density,
      // the next ones have each 2/3 density of
      // the previous one (See *1).
      #declare F = 0;
      #while (B>1)
         #declare F = F+1;
         #declare B = B-1;
      #end
      
      #declare B =
         (B<0.15?0:(B>0.85?1:(B-0.15)/0.7));
      
      #declare Color =
      color <
         zto(sin((B+0/3+1/4)*2*pi)+1/2),
         zto(sin((B+1/3+1/4)*2*pi)+1/2),
         zto(sin((B+2/3+1/4)*2*pi)+1/2)
      >*pow(B,2)/pow(1.5,F);                     // *1
      
      [
         pigment {color Color}
         normal {onion +A*cd_dispertion}
         finish {
            ambient 0
            diffuse 0
            phong cd_phong*8*cd_cycles+1
            phong_size cd_phong_size
            metallic 1
         }
      ]
      [
         pigment {color Color}
         normal {onion -A*cd_dispertion}
         finish {
            ambient 0
            diffuse 0
            phong cd_phong*8*cd_cycles+1
            phong_size cd_phong_size
            metallic 1
         }
      ]
   #end
#declare A = A+(1/cd_samples);
#end

// Here ends the cd texture.
   }
   scale cd_scale
}

// The cd object.
#declare cd_object =
union {
   difference {
      cylinder {0, +0.015*y, 1}
      cylinder {-y, +y, 0.1}
      pigment {color transmit 1}
      finish {phong cd_phong phong_size cd_phong_size}
      interior {ior 1.5}
   }
   difference {
      cylinder {0, +0.01502*y, 0.985}
      cylinder {-y, +y, 0.3}
      plane {y, 0.01499 texture {cd_texture}}
      texture {cd_front_texture}
   }
}
