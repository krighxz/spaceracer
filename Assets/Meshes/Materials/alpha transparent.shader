Shader "Unlit/AlphaSelfIllum" {
    Properties {
        _Color ("Color Tint", Color) = (1,1,1,1)
    }
    Category {
       Lighting On
       ZWrite Off
       Cull Off
       Blend SrcAlpha OneMinusSrcAlpha
       Tags {Queue=Transparent}
       SubShader {
            Material {
               Emission [_Color]
            }
            Pass {
            	CGPROGRAM
				#include "UnityCG.cginc"
				#pragma target 4.0
				#pragma vertex vert
				#pragma fragment frag
              	
              	half4 _Color;
              	
				struct v2g 
				{
	    			float4  pos : SV_POSITION;
	    			float2  uv : TEXCOORD0;
				};
				
				struct g2f 
				{
	    			float4  pos : SV_POSITION;
	    			float2  uv : TEXCOORD0;
	    			float3 dist : TEXCOORD1;
				};

				v2g vert(appdata_base v)
				{
	    			v2g OUT;
	    			OUT.pos = mul(UNITY_MATRIX_MVP, v.vertex);
	    			OUT.uv = v.texcoord; //the uv's arent used in this shader but are included in case you want to use them
	    			return OUT;
				}
              	
              	half4 frag() : COLOR
				{
	 				return _Color;				
				}
			
			ENDCG
            }
        } 
    }
}