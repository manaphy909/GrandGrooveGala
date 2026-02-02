Shader "Custom/StencilMask" {
    SubShader {
        Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }
        Pass {
            ColorMask 0        // Make it invisible
            ZWrite Off         // Don't hide background walls
            
            Stencil {
                Ref 1
                Comp Always
                Pass Replace   // Write "1" to the stencil buffer
            }
        }
    }
}