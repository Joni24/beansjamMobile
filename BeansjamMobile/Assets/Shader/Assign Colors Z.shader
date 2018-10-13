// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Assign Colors Z"
{
	Properties
	{
		_ColorMain("Main Color", Color) = (0.5, 0.5, 0.5, 1.0)
		_ColorBorder("Border", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex("Texture to blend", 2D) = "" {}
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
	}


		// Pass 1 draws all the circles with alpha.  They will overlap.
		Pass
	{
		Zwrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
	half4 _ColorMain;
	half4 _ColorBorder;

	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv  : TEXCOORD0;
	};


	v2f vert(appdata_base v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}


	// Convert black to the main color, and white to the border color.
	half4 frag(v2f i) : COLOR
	{
		// get the texture's color for this pixel
		half4 color = tex2D(_MainTex, i.uv);

		// get how far apart the border and main color are
		half4 delta = _ColorBorder - _ColorMain;

		// the final color is the percentage difference between the two.  more white = more border color.  less white = less border color.
		half4 main = _ColorMain + (color * delta);

		// manually set the alpha
		main.a = color.a;

		return main;
	}

		ENDCG
	}


		// Pass 2 redraws just the inner circle and pulls it towards the camera.  White texture pixels become alpha.
		Pass
	{
		Offset - 1, -1

		Blend SrcAlpha OneMinusSrcAlpha

		// ditch any pixels with >50% alpha
		AlphaTest Greater 0.5

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
	half4 _ColorMain;
	half4 _ColorBorder;

	struct v2f
	{
		float4 pos : SV_POSITION;
		float2 uv  : TEXCOORD0;
	};

	v2f vert(appdata_base v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	}

	half4 frag(v2f i) : COLOR
	{
		// get the texture's color for this pixel
		half4 color = tex2D(_MainTex, i.uv);

		// set the main color for everything drawn
		half4 main = _ColorMain;

		// make white become transparent
		main.a = min(color.a, 1 - color.r);

		return main;
	}

		ENDCG
	}
	}
}