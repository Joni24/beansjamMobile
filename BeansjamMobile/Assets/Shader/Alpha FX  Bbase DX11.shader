Shader "AE/Alpha FX Base DX11"
{

	Properties
	{
		_Color("Direct Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex("Main Diffuse (RGBA)", 2D) = "" {}
	_AlphaTex("AlphaPad (RGBA)", 2D) = "" {}
	}

		SubShader
	{


		Tags
	{
		"Queue" = "Geometry+1"
		"RenderType" = "Transparent"
		"IgnoreProjector" = "True"
	}
		Pass
	{
		Colormask RGBA
		AlphaTest Less 0.5
		//            ZTest GEqual
		Offset - 100000, 1
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"


		uniform sampler2D _AlphaTex;
	half4 _Color;


	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv  : TEXCOORD0;
	};



	v2f vert(appdata_base v)
	{
		v2f o;
		UNITY_INITIALIZE_OUTPUT(v2f, o);
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}



	half4 frag(v2f i) : COLOR
	{
		half4 sample = tex2D(_AlphaTex, i.uv);

	//clip(sample.a * -0.01);
	if (sample.a > 0)
		discard;
	return sample;
	}


		ENDCG
	}

		Tags
	{
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
		"IgnoreProjector" = "True"
	}
		Pass
	{

		Colormask RGBA
		Zwrite on
		//            ZTest LEqual
		AlphaTest Greater 0.5
		Blend SrcAlpha OneMinusSrcAlpha
		//Offset -0.01, 1


		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"



		uniform sampler2D _MainTex;
	half4 _Color;



	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv  : TEXCOORD0;
	};



	v2f vert(appdata_base v)
	{
		v2f o;
		UNITY_INITIALIZE_OUTPUT(v2f, o);
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}



	half4 frag(v2f i) : COLOR
	{
		half4 sample = tex2D(_MainTex, i.uv) * _Color;
	if (sample.a < 0.5)
		discard;
	return sample;
	}



		ENDCG

	}


	}

		Fallback "VertexLit"

}