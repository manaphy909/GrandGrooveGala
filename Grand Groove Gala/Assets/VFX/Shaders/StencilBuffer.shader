Shader "Custom/Mask"
{
	Properties{}

	SubShader{

		Tags {
			"RenderType" = "Opaque"
		}

		Pass {
			ColorMask 0
			ZWrite Off
		}
	}
}